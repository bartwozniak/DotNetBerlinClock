using System;
using System.Collections.Generic;
using System.Linq;
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
            var hours = time.Hour;
            var countOn = hours / 5;
            var lightsOn = CreateLights(Light.On, countOn);
            var lightsOff = CreateLights(Light.Off, 4 - countOn);

            FirstRow = lightsOn.Concat(lightsOff).ToList();
        }

        private static IEnumerable<Light> CreateLights(Light element, int count)
        {
            for (int i = 0; i < count; ++i)
                yield return element;
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
