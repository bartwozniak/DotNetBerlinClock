using BerlinClock.Lights;

namespace BerlinClock
{
    public class BerlinClock
    {
        public SecondsLight SecondsLight { get; private set; }

        public BerlinClock(int hours, int minutes, int seconds)
        {
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
