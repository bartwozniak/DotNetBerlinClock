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

        [TestCase(-1, 00, 00)]
        [TestCase(-100, 00, 00)]
        [TestCase(-9999, 00, 00)]
        public void CannotCreateTimeWithNegativeHours(int hours, int minutes, int seconds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Time(hours, minutes, seconds));
        }

        [TestCase(25, 00, 00)]
        [TestCase(30, 00, 00)]
        [TestCase(9999, 00, 00)]
        public void CannotCreateTimeWithHoursLargerThan24(int hours, int minutes, int seconds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Time(hours, minutes, seconds));
        }

        [TestCase(24, 01, 00)]
        [TestCase(24, 24, 00)]
        [TestCase(24, 59, 00)]
        public void CannotCreateTimeWithHour24AndMinutesNotZero(int hours, int minutes, int seconds)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Time(hours, minutes, seconds));
        }
    }
}
