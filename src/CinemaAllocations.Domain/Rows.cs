using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class Rows
    {
        private readonly Dictionary<string, Row> _rows;

        public Rows(Dictionary<string,Row> rows)
        {
            _rows = rows;
        }
    }
}