using System.Collections.Generic;
using System.Linq;

namespace CinemaAllocations.Domain
{
    public class Rows
    {
        private readonly Dictionary<string, Row> _rows;

        public List<Row> Values => _rows.Values.ToList();

        private Rows(Dictionary<string, Row> rows)
        {
            _rows = rows;
        }

        internal void UpdateRow(Row row)
        {
            _rows[row.Name] = row;
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