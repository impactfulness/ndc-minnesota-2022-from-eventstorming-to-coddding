using System;
using System.Collections.Generic;
using System.Linq;
using Value;

namespace CinemaAllocations.Domain
{
    public class Seat : ValueType<Seat>
    {
        public RowName RowName { get; }
        public SeatNumber Number { get; }
        public SeatAvailability SeatAvailability { get; }

        private Seat(RowName rowName, SeatNumber number, SeatAvailability seatAvailability)
        {
            RowName = rowName;
            Number = number;
            SeatAvailability = seatAvailability;
        }

        internal Seat ReserveSeats()
        {
            return new Seat(RowName, Number, SeatAvailability.Reserved);
        }

        internal bool IsAvailable()
        {
            return SeatAvailability == SeatAvailability.Available;
        }

        private bool SameSeatLocation(Seat seat)
        {
            return RowName.Equals(seat.RowName) && Number == seat.Number;
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

        public static Seat CreateFrom(string rowName, uint number, SeatAvailability seatAvailability)
        {
            return new Seat((RowName)rowName, (SeatNumber)number, seatAvailability);
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new object[] { RowName, Number, SeatAvailability };
        }

        public override string ToString()
        {
            return $"{RowName}{Number}";
        }
    }
}