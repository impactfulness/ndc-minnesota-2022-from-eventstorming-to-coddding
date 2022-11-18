using System.Collections.Generic;
using System.Linq;
using Value;

namespace CinemaAllocations.Domain
{
    public class Seat : ValueType<Seat>
    {
        public RowName RowName { get; set; }
        public string RowNameOld { get; }
        public uint Number { get; }
        public SeatAvailability SeatAvailability { get; }

        public Seat(string rowName, uint number, SeatAvailability seatAvailability)
        {
            RowNameOld = rowName;
            Number = number;
            SeatAvailability = seatAvailability;
        }

        internal Seat ReserveSeats()
        {
            return new Seat(RowNameOld, Number, SeatAvailability.Reserved);
        }

        internal bool IsAvailable()
        {
            return SeatAvailability == SeatAvailability.Available;
        }

        private bool SameSeatLocation(Seat seat)
        {
            return RowNameOld.Equals(seat.RowNameOld) && Number == seat.Number;
        }

        internal bool IsAdjacentWith(List<Seat> seats)
        {
            var orderedSeats = seats.OrderBy(s => s.Number).ToList();

            foreach (var seat in orderedSeats)
            {
                if (Number + 1 == seat.Number || Number - 1 == seat.Number)
                    return true;
            }

            return false;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new object[] { RowNameOld, Number, SeatAvailability };
        }

        public override string ToString()
        {
            return $"{RowNameOld}{Number}";
        }
    }
}