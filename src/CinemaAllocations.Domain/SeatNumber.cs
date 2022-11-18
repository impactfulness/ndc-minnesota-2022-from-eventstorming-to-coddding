using System;

namespace CinemaAllocations.Domain
{
    public struct SeatNumber: IEquatable<SeatNumber>
    {
        public bool Equals(SeatNumber other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return obj is SeatNumber other && Equals(other);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}