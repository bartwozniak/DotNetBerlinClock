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
            return MakeMajorTickLights(time.Hour, 5, 4);
        }

        private IList<Light> MakeSecondRow(Time time)
        {
            return MakeMinorTickLights(time.Hour, 5, 4);
        }

        private IList<Light> MakeThirdRow(Time time)
        {
            return MakeMajorTickLights(time.Minute, 5, 11);
        }

        private IList<Light> MakeFourthRow(Time time)
        {
            return MakeMinorTickLights(time.Minute, 5, 4);
        }

        private IList<Light> MakeMajorTickLights(int value, int tickValue, int lightsCount)
        {
            var countOn = value / tickValue;
            return MakeLights(lightsCount, countOn);
        }

        private IList<Light> MakeMinorTickLights(int value, int tickValue, int lightsCount)
        {
            var countOn = value % tickValue;
            return MakeLights(lightsCount, countOn);
        }

        private static IList<Light> MakeLights(int lightsCount, int countOn)
        {
            var lightsOn = CreateLights(Light.On, countOn);
            var lightsOff = CreateLights(Light.Off, lightsCount - countOn);

            return lightsOn.Concat(lightsOff).ToList();

            IEnumerable<Light> CreateLights(Light element, int count)
            {
                for (int i = 0; i < count; ++i)
                    yield return element;
            }
        }
    }
}
