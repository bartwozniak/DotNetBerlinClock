using System;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class StringFormatterTests
    {
        [Test]
        public void WhenFormattingBerlinClockOutputHasFiveLines()
        {
            var formatter = new StringFormatter();
            var output = formatter.Format(new BerlinClock(new Time(0, 0, 0)));

            Assert.That(output.Split(Environment.NewLine).Length, Is.EqualTo(5));
        }

        [TestCase(0, "Y")]
        [TestCase(1, "O")]
        public void WhenFormattingBerlinClockSecondsIsDenotedCorrectly(int second, string expectedOutput)
        {
            var formatter = new StringFormatter();
            var output = formatter.Format(new BerlinClock(new Time(0, 0, second)));
            var secondsOutput = output.Split(Environment.NewLine)[0];

            Assert.That(secondsOutput, Is.EqualTo(expectedOutput));
        }
    }
}
