using System;
using BerlinClock.Lights;

namespace BerlinClock
{
    public class BerlinClock
    {
        public SecondsLight SecondsLight { get; private set; }

        public BerlinClock(int hours, int minutes, int seconds)
        {
            if (seconds < 0)
                throw new ArgumentOutOfRangeException(nameof(seconds), seconds, "Cennot accept negative value for seconds.");
            if (seconds >= 60)
                throw new ArgumentOutOfRangeException(nameof(seconds), seconds, "Cennot accept value larger than 59 for seconds.");


            if (IsEven(seconds))
                SecondsLight = SecondsLight.On;
            else
                SecondsLight = SecondsLight.Off;
        }

        private bool IsEven(int digit)
        {
            return digit % 2 == 0;
        }

    }
}
