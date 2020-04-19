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
        public IList<Light> SecondRow { get; private set; }

        public BerlinClock(Time time)
        {
            SecondsLight = MakeSecondsLight(time);
            FirstRow = MakeFirstRow(time);
            SecondRow = MakeSecondRow(time);
        }

        private Light MakeSecondsLight(Time time)
        {
            if (IsEven(time.Second))
                return Light.On;

            return Light.Off;

            bool IsEven(int digit)
            {
                return digit % 2 == 0;
            }
        }

        private IList<Light> MakeFirstRow(Time time)
        {
            var hours = time.Hour;
            var countOn = hours / 5;
            var lightsOn = CreateLights(Light.On, countOn);
            var lightsOff = CreateLights(Light.Off, 4 - countOn);

            return lightsOn.Concat(lightsOff).ToList();
        }

        private IList<Light> MakeSecondRow(Time time)
        {
            if (time.Hour != 0)
                return new[] { Light.On, Light.Off, Light.Off, Light.Off };

            return new Light[4];
        }

        private static IEnumerable<Light> CreateLights(Light element, int count)
        {
            for (int i = 0; i < count; ++i)
                yield return element;
        }
    }
}
