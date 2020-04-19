using System;

namespace BerlinClock
{
    public readonly struct Time
    {
        public readonly int Hour { get; }
        public readonly int Minute { get; }
        public readonly int Second { get; }

        public Time(int hour, int minute, int second) : this()
        {
            Hour = hour;
            ValidateHours(hour);

            Minute = minute;

            ValidateSeconds(second);
            Second = second;
        }

        private void ValidateHours(int hour)
        {
            if (hour < 0)
                throw new ArgumentOutOfRangeException(nameof(Hour), hour, "Cennot accept negative value for hours.");
            if (hour > 24)
                throw new ArgumentOutOfRangeException(nameof(Hour), hour, "Cennot accept value larger than 24 for hours.");
        }

        private void ValidateSeconds(int second)
        {
            if (second < 0)
                throw new ArgumentOutOfRangeException(nameof(Second), second, "Cennot accept negative value for seconds.");
            if (second > 59)
                throw new ArgumentOutOfRangeException(nameof(Second), second, "Cennot accept value larger than 59 for seconds.");
        }
    }
}
