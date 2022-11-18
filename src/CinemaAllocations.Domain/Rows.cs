using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class Rows
    {
        private readonly Dictionary<string, Row> _rows;

        private Rows(Dictionary<string, Row> rows)
        {
            _rows = rows;
        }

        internal SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            var numberOfSeatsAvailable = 0;
            foreach (var row in _rows.Values)
            {
                var seatsAllocated = row.AllocateSeats(allocateSeats);
                if (seatsAllocated.GetType() != typeof(NoPossibleAllocationsFound))
                {
                    var updatedRow = row.MakeSeatsReserved(seatsAllocated.ReservedSeats);
                    _rows[row.Name] = row;
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

        public int TotalNumberOfRows()
        {
            return _rows.Count;
        }

        internal static Rows CreateFrom(Dictionary<string, Row> rows)
        {
            return new Rows(rows);
        }
    }
}