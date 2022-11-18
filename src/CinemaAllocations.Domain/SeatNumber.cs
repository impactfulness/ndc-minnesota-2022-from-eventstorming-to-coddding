using System;

namespace CinemaAllocations.Domain
{
    public readonly struct SeatNumber : IEquatable<SeatNumber>, IComparable<SeatNumber>
    {
        private readonly uint _value;

        private SeatNumber(uint seatNumber)
        {
            if (seatNumber == 0)
                throw new ArgumentOutOfRangeException(nameof(seatNumber), seatNumber, "Seat number cannot be zero.");

            _value = seatNumber;
        }

        public static implicit operator uint(SeatNumber seatNumber)
        {
            return seatNumber._value;
        }

        public static explicit operator SeatNumber(uint seatNumber)
        {
            return new SeatNumber(seatNumber);
        }

        public bool Equals(SeatNumber other)
        {
            return _value == other._value;
        }

        public int CompareTo(SeatNumber other)
        {
            return _value.CompareTo(other._value);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            return obj is SeatNumber other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(SeatNumber left, SeatNumber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SeatNumber left, SeatNumber right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}