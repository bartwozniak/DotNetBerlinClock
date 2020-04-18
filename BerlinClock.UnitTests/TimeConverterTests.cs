using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class Tests
    {
        [TestCase("00:00:00")]
        [TestCase("24:00:00")]
        public void WhenConvertingMidnightFirstLightShouldBeYellow(string midnight)
        {
            var berlinClock = new TimeConverter();
            var result = berlinClock.ConvertTime(midnight);

            StringAssert.StartsWith(result, "Y");
        }
    }
}