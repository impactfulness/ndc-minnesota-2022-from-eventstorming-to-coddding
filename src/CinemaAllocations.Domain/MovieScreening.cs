using System;
using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class MovieScreening
    {
        public IReadOnlyDictionary<string, Row> Rows => _rows.ToDictionary();

        private readonly Rows _rows;

        private MovieScreening(Rows rows)
        {
            _rows = rows;
        }

        public SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            var numberOfSeatsAvailable = 0;
            foreach (var row in _rows.Values)
            {
                var seatsAllocated = row.AllocateSeats(allocateSeats);
                if (seatsAllocated.GetType() != typeof(NoPossibleAllocationsFound))
                {
                    var updatedRow = row.MakeSeatsReserved(seatsAllocated.ReservedSeats);
                    _rows.UpdateRow(updatedRow);
                    return seatsAllocated;
                }

                numberOfSeatsAvailable = numberOfSeatsAvailable + row.ReturnNumberOfSeatsAvailable();
            }

            if (numberOfSeatsAvailable >= allocateSeats.PartyRequested)
            {
                return new NoPossibleAdjacentSeatsFound(allocateSeats.PartyRequested);
            }

            return new NoPossibleAllocationsFound(allocateSeats.PartyRequested);
        }

        public static MovieScreening CreateFrom(Dictionary<string, Row> rows)
        {
            return new MovieScreening(Domain.Rows.CreateFrom(rows));
        }
    }
}