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
            var berlinClock = new BerlinClock(new Time(seconds));
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
            var berlinClock = new BerlinClock(new Time(seconds));
            var result = berlinClock.SecondsLight;

            Assert.IsFalse(result.IsOn);
        }

        [TestCase(00, 00, 00)]
        public void WhenConvertingMidnightFirstRowIsOff(int hours, int minutes, int seconds)
        {
            var berlinClock = new BerlinClock(new Time(seconds));
            var row = berlinClock.FirstRow;

            Assert.IsFalse(row.Any(l => l.IsOn));
        }
    }
}
