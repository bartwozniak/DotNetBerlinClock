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

        [TestCase(0, "OOOO")]
        [TestCase(1, "OOOO")]
        [TestCase(5, "ROOO")]
        [TestCase(11, "RROO")]
        [TestCase(18, "RRRO")]
        [TestCase(23, "RRRR")]
        [TestCase(24, "RRRR")]
        public void WhenFormattingBerlinClockTopRowHoursAreDenotedCorrectly(int hour, string expectedOutput)
        {
            var formatter = new StringFormatter();
            var output = formatter.Format(new BerlinClock(new Time(hour, 0, 0)));
            var secondsOutput = output.Split(Environment.NewLine)[1];

            Assert.That(secondsOutput, Is.EqualTo(expectedOutput));
        }

        [TestCase(0, "OOOO")]
        [TestCase(1, "ROOO")]
        [TestCase(5, "OOOO")]
        [TestCase(6, "ROOO")]
        [TestCase(11, "ROOO")]
        [TestCase(18, "RRRO")]
        [TestCase(23, "RRRO")]
        [TestCase(24, "RRRR")]
        public void WhenFormattingBerlinClockBottomRowHoursAreDenotedCorrectly(int hour, string expectedOutput)
        {
            var formatter = new StringFormatter();
            var output = formatter.Format(new BerlinClock(new Time(hour, 0, 0)));
            var secondsOutput = output.Split(Environment.NewLine)[2];

            Assert.That(secondsOutput, Is.EqualTo(expectedOutput));
        }

        [TestCase(00, "OOOOOOOOOOO")]
        [TestCase(01, "OOOOOOOOOOO")]
        [TestCase(05, "YOOOOOOOOOO")]
        [TestCase(11, "YYOOOOOOOOO")]
        [TestCase(18, "YYROOOOOOOO")]
        [TestCase(23, "YYRYOOOOOOO")]
        [TestCase(25, "YYRYYOOOOOO")]
        [TestCase(32, "YYRYYROOOOO")]
        [TestCase(39, "YYRYYRYOOOO")]
        [TestCase(43, "YYRYYRYYOOO")]
        [TestCase(45, "YYRYYRYYROO")]
        [TestCase(51, "YYRYYRYYRYO")]
        [TestCase(56, "YYRYYRYYRYY")]
        public void WhenFormattingBerlinClockTopRowMinutesAreDenotedCorrectly(int minute, string expectedOutput)
        {
            var formatter = new StringFormatter();
            var output = formatter.Format(new BerlinClock(new Time(0, minute, 0)));
            var secondsOutput = output.Split(Environment.NewLine)[3];

            Assert.That(secondsOutput, Is.EqualTo(expectedOutput));
        }

        [TestCase(00, "OOOO")]
        [TestCase(01, "YOOO")]
        [TestCase(05, "OOOO")]
        [TestCase(11, "YOOO")]
        [TestCase(18, "YYYO")]
        [TestCase(23, "YYYO")]
        [TestCase(25, "OOOO")]
        [TestCase(32, "YYOO")]
        [TestCase(39, "YYYY")]
        [TestCase(43, "YYYO")]
        [TestCase(45, "OOOO")]
        [TestCase(51, "YOOO")]
        [TestCase(59, "YYYY")]
        public void WhenFormattingBerlinClockBottomRowMinutesAreDenotedCorrectly(int minute, string expectedOutput)
        {
            var formatter = new StringFormatter();
            var output = formatter.Format(new BerlinClock(new Time(0, minute, 0)));
            var secondsOutput = output.Split(Environment.NewLine)[4];

            Assert.That(secondsOutput, Is.EqualTo(expectedOutput));
        }
    }
}
