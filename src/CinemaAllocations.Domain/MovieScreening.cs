using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class MovieScreening
    {
        internal Rows Rows { get; }

        private MovieScreening(Rows rows)
        {
            Rows = rows;
        }

        internal SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            return Rows.AllocateSeats(allocateSeats);
        }

        public static MovieScreening CreateFrom(Dictionary<string, Row> rows)
        {
            return new MovieScreening(Domain.Rows.CreateFrom(rows));
        }
    }
}