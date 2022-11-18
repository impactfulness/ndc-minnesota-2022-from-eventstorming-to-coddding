using System;

namespace CinemaAllocations.Domain
{
    public struct RowName : IEquatable<RowName>
    {
        private readonly string _value;

        private RowName(string rowName)
        {
            if (string.IsNullOrWhiteSpace(rowName))
                throw new ArgumentException("Row name cannot be null or whitespace.", nameof(rowName));

            _value = rowName;
        }

        public static implicit operator string(RowName rowName)
        {
            return rowName._value;
        }

        public static explicit operator RowName(string rowName)
        {
            return new RowName(rowName);
        }

        public bool Equals(RowName other)
        {
            return _value == other._value;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            return obj is RowName other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}