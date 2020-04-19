using System;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class TimeTests
    {
        [TestCase(10, 10, -1)]
        [TestCase(10, 10, -10)]
        [TestCase(10, 10, -100000)]
        public void CannotCreateTimeWithNegativeSeconds(int hours, int minutes, int seconds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Time(hours, minutes, seconds));
        }

        [TestCase(10, 10, 60)]
        [TestCase(10, 10, 100)]
        [TestCase(10, 10, 99999)]
        public void CannotCreateTimeWithSecondsLargerThan59(int hours, int minutes, int seconds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Time(hours, minutes, seconds));
        }
    }
}
