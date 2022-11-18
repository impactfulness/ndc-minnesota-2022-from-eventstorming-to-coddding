using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class Rows
    {
        private readonly Dictionary<string, Row> _rows;

        public Dictionary<string, Row>.ValueCollection Values => _rows.Values;

        public Rows(Dictionary<string, Row> rows)
        {
            _rows = rows;
        }

        internal void UpdateRow(Row rowToUpdate)
        {
            _rows[rowToUpdate.Name] = rowToUpdate;
        }
    }
}