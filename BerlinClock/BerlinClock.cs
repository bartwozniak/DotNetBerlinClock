using System;
using System.Collections.Generic;
using BerlinClock.Lights;

namespace BerlinClock
{
    public class BerlinClock
    {
        public Light SecondsLight { get; private set; }
        public IList<Light> FirstRow { get; private set; }

        public BerlinClock(Time time)
        {
            MakeSecondsLight(time);
            MakeFirstRow(time);
        }

        private void MakeFirstRow(Time time)
        {
            FirstRow = new Light[4];
        }

        private void MakeSecondsLight(Time time)
        {
            if (IsEven(time.Second))
                SecondsLight = Light.On;
            else
                SecondsLight = Light.Off;

            bool IsEven(int digit)
            {
                return digit % 2 == 0;
            }
        }

    }
}
