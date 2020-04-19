using System;

namespace BerlinClock
{
    public readonly struct Time
    {
        public readonly int Second { get; }

        public Time(int second) : this()
        {
            ValidateSeconds(second);
            Second = second;
        }

        private void ValidateSeconds(int second)
        {
            if (second < 0)
                throw new ArgumentOutOfRangeException(nameof(second), second, "Cennot accept negative value for seconds.");
            if (second > 59)
                throw new ArgumentOutOfRangeException(nameof(second), second, "Cennot accept value larger than 59 for seconds.");
        }
    }
}
