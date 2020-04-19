using System;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class SimpleTimeParserTests
    {
        [TestCase("00:00:00", 0, 0, 0)]
        [TestCase("01:01:01", 1, 1, 1)]
        [TestCase("10:10:10", 10, 10, 10)]
        [TestCase("24:00:00", 24, 0, 0)]
        public void WhenParsingTimeStringsComponentsCanBeSeparatedByColon(string testString, int expectedHour, int expectedMinute, int expectedSecond)
        {
            var parser = new SimpleTimeParser();
            var time = parser.Parse(testString);

            Assert.That(time.Hour, Is.EqualTo(expectedHour));
            Assert.That(time.Minute, Is.EqualTo(expectedMinute));
            Assert.That(time.Second, Is.EqualTo(expectedSecond));
        }

        [Test]
        public void WhenParsingTimeStringsWithoutAllComponentsParserThrows()
        {
            var testString = "11:22";
            var parser = new SimpleTimeParser();

            Assert.Throws<FormatException>(() => parser.Parse(testString));
        }

        [Test]
        public void WhenParsingTimeArgumentMustBeGiven()
        {
            var parser = new SimpleTimeParser();

            Assert.Throws<ArgumentException>(() => parser.Parse(null));
        }
    }
}
