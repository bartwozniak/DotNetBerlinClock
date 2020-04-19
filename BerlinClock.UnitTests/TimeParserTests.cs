using System;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class TimeParserTests
    {
        [TestCase("00:00:00", 0, 0, 0)]
        [TestCase("01:01:01", 1, 1, 1)]
        [TestCase("10:10:10", 10, 10, 10)]
        public void WhenParsingTimeStringsComponentsCanBeSeparatedByColon(string testString, int expectedHour, int expectedMinute, int expectedSecond)
        {
            var parser = new TimeParser();
            var time = parser.Parse(testString);

            Assert.That(time.Hour, Is.EqualTo(expectedHour));
            Assert.That(time.Minute, Is.EqualTo(expectedMinute));
            Assert.That(time.Second, Is.EqualTo(expectedSecond));
        }
    }
}
