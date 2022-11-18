using System;

namespace CinemaAllocations.Domain
{
    public struct RowName : IEquatable<RowName>
    {
        private readonly string _rowName;

        private RowName(string rowName)
        {
            if (string.IsNullOrWhiteSpace(rowName))
                throw new ArgumentException("Row name cannot be null or whitespace.", nameof(rowName));

            _rowName = rowName;
        }

        public bool Equals(RowName other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return obj is RowName other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _rowName.GetHashCode();
        }
    }
}