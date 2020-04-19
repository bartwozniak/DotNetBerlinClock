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
                return new Light(true, Color.Yellow);

            return new Light(false, Color.Yellow);

            bool IsEven(int digit)
            {
                return digit % 2 == 0;
            }
        }

        private IList<Light> MakeFirstRow(Time time)
        {
            return MakeMajorTickLights(time.Hour, 5, 4, Color.Red);
        }

        private IList<Light> MakeSecondRow(Time time)
        {
            return MakeMinorTickLights(time.Hour, 5, 4, Color.Red);
        }

        private IList<Light> MakeThirdRow(Time time)
        {
            var qarterIndices = new int[] { 2, 5, 8 };
            return MakeMajorTickLights(time.Minute, 5, 11, idx => qarterIndices.Contains(idx) ? Color.Red : Color.Yellow);
        }

        private IList<Light> MakeFourthRow(Time time)
        {
            return MakeMinorTickLights(time.Minute, 5, 4, Color.Yellow);
        }

        private IList<Light> MakeMajorTickLights(int value, int tickValue, int lightsCount, Color color)
        {
            var countOn = value / tickValue;
            return MakeLights(lightsCount, countOn, color);
        }

        private IList<Light> MakeMajorTickLights(int value, int tickValue, int lightsCount, Func<int, Color> colorSelector)
        {
            var countOn = value / tickValue;
            return MakeLights(lightsCount, countOn, colorSelector);
        }

        private IList<Light> MakeMinorTickLights(int value, int tickValue, int lightsCount, Color color)
        {
            var countOn = value % tickValue;
            return MakeLights(lightsCount, countOn, color);
        }

        private static IList<Light> MakeLights(int lightsCount, int countOn, Func<int, Color> colorSelector)
        {
            var lightsOn = InitLights(true, colorSelector, 0, countOn);
            var lightsOff = InitLights(false, colorSelector, countOn, lightsCount);

            return lightsOn.Concat(lightsOff).ToList();

            IEnumerable<Light> InitLights(bool value, Func<int, Color> colorSelector, int startIndex, int endIndex)
            {
                for (int i = startIndex; i < endIndex; ++i)
                    yield return new Light(value, colorSelector(i));
            }
        }

        private static IList<Light> MakeLights(int lightsCount, int countOn, Color color)
        {
            return MakeLights(lightsCount, countOn, _ => color);
        }
    }
}
