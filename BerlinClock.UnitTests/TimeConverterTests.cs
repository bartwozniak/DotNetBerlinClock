using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class Tests
    {
        [TestCase("24:00:00")]
        [TestCase("00:00:00")]
        [TestCase("00:00:20")]
        [TestCase("00:00:44")]
        [TestCase("10:55:04")]
        [TestCase("04:37:08")]
        [TestCase("22:12:58")]
        public void WhenConvertingEvenSecondsFirstLightShouldBeYellow(string time)
        {
            var berlinClock = new TimeConverter();
            var result = berlinClock.ConvertTime(time);

            StringAssert.StartsWith(result, "Y");
        }

        [TestCase("00:00:01")]
        [TestCase("00:00:11")]
        [TestCase("00:00:31")]
        [TestCase("10:55:05")]
        [TestCase("04:37:59")]
        [TestCase("22:12:17")]
        public void WhenConvertingOddSecondsFirstLightShouldBeOff(string time)
        {
            var berlinClock = new TimeConverter();
            var result = berlinClock.ConvertTime(time);

            StringAssert.StartsWith(result, "O");
        }
    }
}