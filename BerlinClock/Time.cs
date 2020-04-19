using System;

namespace BerlinClock
{
    public readonly struct Time
    {
        public readonly int Hour { get; }
        public readonly int Minute { get; }
        public readonly int Second { get; }

        public Time(int hour, int minute, int second)
        {
            ValidateArgument(nameof(hour), hour, 0, 24);
            ValidateArgument(nameof(second), second, 0, 59);
            ValidateTime(hour, minute);

            Hour = hour;
            Minute = minute;
            Second = second;
        }

        private static void ValidateTime(int hour, int minute)
        {
            if (hour == 24 && minute != 0)
                throw new ArgumentOutOfRangeException($"Cannot accept value {minute} for minutes when hour is {hour}.");
        }

        private static void ValidateArgument(string argName, int argValue, int min, int max)
        {
            if (argValue < min)
                throw new ArgumentOutOfRangeException(argName, argValue, $"Cannot accept value lower than {min}.");
            if (argValue > max)
                throw new ArgumentOutOfRangeException(argName, argValue, $"Cannot accept value larger than {max}.");
        }
    }
}
