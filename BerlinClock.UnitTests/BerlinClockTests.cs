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

            Assert.That(row.Take(expectedOn).Select(l => l.IsOn), Has.Exactly(expectedOn).True);
            Assert.That(row.Skip(expectedOn).Select(l => l.IsOn), Has.Exactly(4 - expectedOn).False);
        }

        [TestCase(00, 00, 00, 0)]
        [TestCase(01, 00, 00, 1)]
        [TestCase(04, 59, 59, 4)]
        [TestCase(05, 00, 00, 0)]
        [TestCase(06, 00, 00, 1)]
        [TestCase(08, 00, 00, 3)]
        [TestCase(10, 00, 00, 0)]
        [TestCase(13, 00, 00, 3)]
        [TestCase(15, 00, 00, 0)]
        [TestCase(16, 00, 00, 1)]
        [TestCase(20, 00, 00, 0)]
        [TestCase(22, 00, 00, 2)]
        public void WhenConvertingHoursCorrectNumberOfLightsInSecondRowIsOn(int hours, int minutes, int seconds, int expectedOn)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.SecondRow;

            Assert.That(row.Take(expectedOn).Select(l => l.IsOn), Has.Exactly(expectedOn).True);
            Assert.That(row.Skip(expectedOn).Select(l => l.IsOn), Has.Exactly(4 - expectedOn).False);
        }

        [TestCase(00, 00, 00, 0)]
        [TestCase(00, 01, 00, 0)]
        [TestCase(00, 05, 00, 1)]
        [TestCase(00, 07, 00, 1)]
        [TestCase(00, 10, 00, 2)]
        [TestCase(00, 15, 00, 3)]
        [TestCase(00, 20, 00, 4)]
        [TestCase(00, 25, 00, 5)]
        [TestCase(00, 30, 00, 6)]
        [TestCase(00, 35, 00, 7)]
        [TestCase(00, 40, 00, 8)]
        [TestCase(00, 45, 00, 9)]
        [TestCase(00, 50, 00, 10)]
        [TestCase(00, 55, 00, 11)]
        public void WhenConvertingMinutesCorrectNumberOfLightsInThirdRowIsOn(int hours, int minutes, int seconds, int expectedOn)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.ThirdRow;

            Assert.That(row.Take(expectedOn).Select(l => l.IsOn), Has.Exactly(expectedOn).True);
            Assert.That(row.Skip(expectedOn).Select(l => l.IsOn), Has.Exactly(11 - expectedOn).False);
        }

        [TestCase(00, 00, 00, 0)]
        [TestCase(00, 01, 00, 1)]
        [TestCase(00, 05, 00, 0)]
        [TestCase(00, 30, 00, 0)]
        [TestCase(00, 32, 00, 2)]
        [TestCase(00, 44, 00, 4)]
        [TestCase(00, 51, 00, 1)]
        [TestCase(00, 59, 00, 4)]
        public void WhenConvertingMinutesCorrectNumberOfLightsInFourthRowIsOn(int hours, int minutes, int seconds, int expectedOn)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.FourthRow;

            Assert.That(row.Take(expectedOn).Select(l => l.IsOn), Has.Exactly(expectedOn).True);
            Assert.That(row.Skip(expectedOn).Select(l => l.IsOn), Has.Exactly(4 - expectedOn).False);
        }
    }
}
