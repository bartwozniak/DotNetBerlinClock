using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class Tests
    {
        [Test]
        public void WhenConvertingMidnightFirstLightShouldBeYellow()
        {
            var berlinClock = new TimeConverter();
            var result = berlinClock.ConvertTime("00:00:00");

            StringAssert.StartsWith(result, "Y");
        }
    }
}