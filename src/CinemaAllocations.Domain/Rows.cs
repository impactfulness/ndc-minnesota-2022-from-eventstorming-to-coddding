using System.Collections.Generic;

namespace CinemaAllocations.Domain
{
    public class Rows
    {
        private readonly Dictionary<string, Row> _rows;

        public Dictionary<string, Row>.ValueCollection Values => _rows.Values;

        private Rows(Dictionary<string, Row> rows)
        {
            _rows = rows;
        }

        internal void UpdateRow(Row rowToUpdate)
        {
            _rows[rowToUpdate.Name] = rowToUpdate;
        }

        internal Dictionary<string, Row> ToDictionary()
        {
            return _rows;
        }

        internal static Rows CreateFrom(Dictionary<string, Row> rows)
        {
            return new Rows(rows);
        }
    }
}