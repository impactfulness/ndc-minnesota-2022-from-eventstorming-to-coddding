using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class MovieScreening
    {
        public IReadOnlyDictionary<string, Row> Rows => _rowsOld;

        private readonly Dictionary<string, Row> _rowsOld;

        public MovieScreening(Dictionary<string, Row> rows)
        {
            _rowsOld = rows;
        }

        public MovieScreening(Rows rows)
        {
            
        }

        public SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            var numberOfSeatsAvailable = 0;
            foreach (var row in _rowsOld.Values)
            {
                var seatsAllocated = row.AllocateSeats(allocateSeats);
                if (seatsAllocated.GetType() != typeof(NoPossibleAllocationsFound))
                {
                    var updatedRow = row.MakeSeatsReserved(seatsAllocated.ReservedSeats);
                    _rowsOld[updatedRow.Name] = updatedRow;
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
    }
}