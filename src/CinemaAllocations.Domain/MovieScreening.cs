using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class MovieScreening
    {
        private readonly Rows _rows;

        internal Rows Rows => _rows;

        private MovieScreening(Rows rows)
        {
            _rows = rows;
        }

        internal SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            return _rows.AllocateSeats(allocateSeats);
        }

        public static MovieScreening CreateFrom(Dictionary<string, Row> rows)
        {
            return new MovieScreening(Domain.Rows.CreateFrom(rows));
        }
    }
}