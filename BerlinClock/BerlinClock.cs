using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Lights;

namespace BerlinClock
{
    public class BerlinClock
    {
        public Light SecondsLight { get; }
        public IEnumerable<Light> FirstRow { get; }
        public IEnumerable<Light> SecondRow { get; }
        public IEnumerable<Light> ThirdRow { get; }
        public IEnumerable<Light> FourthRow { get; }

        public BerlinClock(Time time)
        {
            SecondsLight = MakeSecondsLight(time);
            FirstRow = MakeFirstRow(time);
            SecondRow = MakeSecondRow(time);
            ThirdRow = MakeThirdRow(time);
            FourthRow = MakeFourthRow(time);
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
            var hours = time.Hour;
            var countOn = hours % 5;
            var lightsOn = CreateLights(Light.On, countOn);
            var lightsOff = CreateLights(Light.Off, 4 - countOn);

            return lightsOn.Concat(lightsOff).ToList();
        }

        private IList<Light> MakeThirdRow(Time time)
        {
            var minutes = time.Minute;
            var countOn = minutes / 5;
            var lightsOn = CreateLights(Light.On, countOn);
            var lightsOff = CreateLights(Light.Off, 11 - countOn);

            return lightsOn.Concat(lightsOff).ToList();
        }

        private IList<Light> MakeFourthRow(Time time)
        {
            var minutes = time.Minute;
            var countOn = minutes % 5;
            var lightsOn = CreateLights(Light.On, countOn);
            var lightsOff = CreateLights(Light.Off, 4 - countOn);

            return lightsOn.Concat(lightsOff).ToList();
        }

        private static IEnumerable<Light> CreateLights(Light element, int count)
        {
            for (int i = 0; i < count; ++i)
                yield return element;
        }
    }
}
