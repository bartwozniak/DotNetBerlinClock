using System;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class TimeParserTests
    {
        [Test]
        public void WhenParsingTimeStringsComponentsCanBeSeparatedByColon()
        {
            var testString = "01:01:01";
            var parser = new TimeParser();
            var time = parser.Parse(testString);

            Assert.That(time.Hour, Is.EqualTo(1));
            Assert.That(time.Minute, Is.EqualTo(1));
            Assert.That(time.Second, Is.EqualTo(1));
        }
    }
}
