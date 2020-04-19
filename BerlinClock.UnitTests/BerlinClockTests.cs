using System.Linq;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class BerlinClockTests
    {
        [TestCase(24, 00, 00)]
        [TestCase(00, 00, 00)]
        [TestCase(00, 00, 20)]
        [TestCase(00, 00, 44)]
        [TestCase(10, 55, 04)]
        [TestCase(04, 37, 08)]
        [TestCase(22, 12, 58)]
        public void WhenConvertingEvenSecondsFirstLightIsOn(int hours, int minutes, int seconds)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var result = berlinClock.SecondsLight;

            Assert.IsTrue(result.IsOn);
        }

        [TestCase(00, 00, 01)]
        [TestCase(00, 00, 11)]
        [TestCase(00, 00, 31)]
        [TestCase(10, 55, 05)]
        [TestCase(04, 37, 59)]
        [TestCase(22, 12, 17)]
        public void WhenConvertingOddSecondsFirstLightIsOff(int hours, int minutes, int seconds)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var result = berlinClock.SecondsLight;

            Assert.IsFalse(result.IsOn);
        }

        [TestCase(00, 00, 00, 0)]
        [TestCase(01, 00, 00, 0)]
        [TestCase(02, 00, 00, 0)]
        [TestCase(03, 00, 00, 0)]
        [TestCase(04, 00, 00, 0)]
        [TestCase(05, 00, 00, 1)]
        [TestCase(05, 10, 10, 1)]
        [TestCase(05, 59, 59, 1)]
        [TestCase(07, 00, 00, 1)]
        [TestCase(07, 30, 21, 1)]
        [TestCase(09, 00, 00, 1)]
        [TestCase(10, 00, 00, 2)]
        [TestCase(10, 13, 45, 2)]
        [TestCase(11, 13, 45, 2)]
        [TestCase(14, 13, 45, 2)]
        [TestCase(15, 00, 00, 3)]
        [TestCase(15, 01, 01, 3)]
        [TestCase(18, 01, 01, 3)]
        [TestCase(20, 00, 00, 4)]
        [TestCase(20, 11, 11, 4)]
        [TestCase(22, 11, 11, 4)]
        [TestCase(24, 00, 00, 4)]
        public void WhenConvertingHoursCorrectNumberOfLightsInFirstRowIsOn(int hours, int minutes, int seconds, int expectedOn)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.FirstRow;

            Assert.IsTrue(row.Take(expectedOn).All(l => l.IsOn), $"First {expectedOn} must be on");
            Assert.IsFalse(row.Skip(expectedOn).Any(l => l.IsOn), $"Remaining lights must be off");
        }

        [TestCase(00, 00, 00)]
        [TestCase(01, 00, 00)]
        [TestCase(04, 00, 00)]
        [TestCase(05, 00, 00)]
        [TestCase(10, 00, 00)]
        [TestCase(15, 00, 00)]
        [TestCase(20, 00, 00)]
        [TestCase(24, 00, 00)]
        public void WhenConvertingHoursFirstRowHasFourLights(int hours, int minutes, int seconds)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.FirstRow;

            Assert.AreEqual(4, row.Count);
        }

        [TestCase(00, 00, 00, 0)]
        [TestCase(01, 00, 00, 1)]
        public void WhenConvertingHoursCorrectNumberOfLightsInSecondRowIsOn(int hours, int minutes, int seconds, int expectedOn)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.SecondRow;

            Assert.IsTrue(row.Take(expectedOn).All(l => l.IsOn), $"First {expectedOn} must be on");
            Assert.IsFalse(row.Skip(expectedOn).Any(l => l.IsOn), $"Remaining lights must be off");
        }
    }
}
