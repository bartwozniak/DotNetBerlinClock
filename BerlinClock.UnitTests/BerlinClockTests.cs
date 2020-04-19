using System.Collections.Generic;
using System.Linq;
using BerlinClock.Lights;
using NUnit.Framework;

namespace BerlinClock.UnitTests
{
    public class BerlinClockTests
    {
        [TestCase(24, 00, 00)]
        [TestCase(00, 00, 00)]
        [TestCase(00, 00, 20)]
        [TestCase(00, 00, 44)]
        [TestCase(10, 55, 04)]
        [TestCase(04, 37, 08)]
        [TestCase(22, 12, 58)]
        public void WhenConvertingEvenSecondsFirstLightIsOn(int hours, int minutes, int seconds)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var result = berlinClock.SecondsLight;

            Assert.IsTrue(result.IsOn);
        }

        [TestCase(00, 00, 01)]
        [TestCase(00, 00, 11)]
        [TestCase(00, 00, 31)]
        [TestCase(10, 55, 05)]
        [TestCase(04, 37, 59)]
        [TestCase(22, 12, 17)]
        public void WhenConvertingOddSecondsFirstLightIsOff(int hours, int minutes, int seconds)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var result = berlinClock.SecondsLight;

            Assert.IsFalse(result.IsOn);
        }

        [TestCase(00, 00, 00, 0)]
        [TestCase(01, 00, 00, 0)]
        [TestCase(02, 00, 00, 0)]
        [TestCase(03, 00, 00, 0)]
        [TestCase(04, 00, 00, 0)]
        [TestCase(05, 00, 00, 1)]
        [TestCase(05, 10, 10, 1)]
        [TestCase(05, 59, 59, 1)]
        [TestCase(07, 00, 00, 1)]
        [TestCase(07, 30, 21, 1)]
        [TestCase(09, 00, 00, 1)]
        [TestCase(10, 00, 00, 2)]
        [TestCase(10, 13, 45, 2)]
        [TestCase(11, 13, 45, 2)]
        [TestCase(14, 13, 45, 2)]
        [TestCase(15, 00, 00, 3)]
        [TestCase(15, 01, 01, 3)]
        [TestCase(18, 01, 01, 3)]
        [TestCase(20, 00, 00, 4)]
        [TestCase(20, 11, 11, 4)]
        [TestCase(22, 11, 11, 4)]
        [TestCase(24, 00, 00, 4)]
        public void WhenConvertingHoursCorrectNumberOfLightsInFirstRowIsOn(int hours, int minutes, int seconds, int expectedOn)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.FirstRow;

            Assert.That(row.Take(expectedOn), Has.Exactly(expectedOn).LightsOn());
            Assert.That(row.Skip(expectedOn), Has.Exactly(4 - expectedOn).LightsOff());
        }

        [TestCase(00, 00, 00, 0)]
        [TestCase(01, 00, 00, 1)]
        [TestCase(04, 59, 59, 4)]
        [TestCase(05, 00, 00, 0)]
        [TestCase(06, 00, 00, 1)]
        [TestCase(08, 00, 00, 3)]
        [TestCase(10, 00, 00, 0)]
        [TestCase(13, 00, 00, 3)]
        [TestCase(15, 00, 00, 0)]
        [TestCase(16, 00, 00, 1)]
        [TestCase(20, 00, 00, 0)]
        [TestCase(22, 00, 00, 2)]
        [TestCase(24, 00, 00, 4)]
        public void WhenConvertingHoursCorrectNumberOfLightsInSecondRowIsOn(int hours, int minutes, int seconds, int expectedOn)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.SecondRow;

            Assert.That(row.Take(expectedOn), Has.Exactly(expectedOn).LightsOn());
            Assert.That(row.Skip(expectedOn), Has.Exactly(4 - expectedOn).LightsOff());
        }

        [TestCase(00, 00, 00, 0)]
        [TestCase(00, 01, 00, 0)]
        [TestCase(00, 05, 00, 1)]
        [TestCase(00, 07, 00, 1)]
        [TestCase(00, 10, 00, 2)]
        [TestCase(00, 15, 00, 3)]
        [TestCase(00, 20, 00, 4)]
        [TestCase(00, 25, 00, 5)]
        [TestCase(00, 30, 00, 6)]
        [TestCase(00, 35, 00, 7)]
        [TestCase(00, 40, 00, 8)]
        [TestCase(00, 45, 00, 9)]
        [TestCase(00, 50, 00, 10)]
        [TestCase(00, 55, 00, 11)]
        public void WhenConvertingMinutesCorrectNumberOfLightsInThirdRowIsOn(int hours, int minutes, int seconds, int expectedOn)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.ThirdRow;

            Assert.That(row.Take(expectedOn), Has.Exactly(expectedOn).LightsOn());
            Assert.That(row.Skip(expectedOn), Has.Exactly(11 - expectedOn).LightsOff());
        }

        [TestCase(00, 00, 00, 0)]
        [TestCase(00, 01, 00, 1)]
        [TestCase(00, 05, 00, 0)]
        [TestCase(00, 30, 00, 0)]
        [TestCase(00, 32, 00, 2)]
        [TestCase(00, 44, 00, 4)]
        [TestCase(00, 51, 00, 1)]
        [TestCase(00, 59, 00, 4)]
        public void WhenConvertingMinutesCorrectNumberOfLightsInFourthRowIsOn(int hours, int minutes, int seconds, int expectedOn)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.FourthRow;

            Assert.That(row.Take(expectedOn), Has.Exactly(expectedOn).LightsOn());
            Assert.That(row.Skip(expectedOn), Has.Exactly(4 - expectedOn).LightsOff());
        }

        [TestCase(00, 00, 00)]
        [TestCase(06, 06, 06)]
        [TestCase(10, 10, 10)]
        [TestCase(15, 15, 15)]
        [TestCase(21, 21, 21)]
        public void WhenClockIsContructedAllHourLightsAreRed(int hours, int minutes, int seconds)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var firstRow = berlinClock.FirstRow;
            var secondRow = berlinClock.SecondRow;

            Assert.That(firstRow, Has.Exactly(4).RedLights());
            Assert.That(secondRow, Has.Exactly(4).RedLights());
        }

        [TestCase(00, 00, 00)]
        [TestCase(06, 06, 06)]
        [TestCase(10, 16, 10)]
        [TestCase(15, 25, 15)]
        [TestCase(21, 40, 21)]
        [TestCase(22, 48, 33)]
        public void WhenClockIsContructedMinutesLightsNotForQuartersAreYellow(int hours, int minutes, int seconds)
        {
            var quarterIndices = new[] { 2, 5, 8 };
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var toCheck =
                berlinClock
                    .ThirdRow
                    .Where((_, index) => !quarterIndices.Contains(index));

            Assert.That(toCheck, Has.Exactly(11 - 3).YellowLights());
        }

        [TestCase(00, 00, 00)]
        [TestCase(06, 06, 06)]
        [TestCase(10, 16, 10)]
        [TestCase(15, 25, 15)]
        [TestCase(21, 40, 21)]
        [TestCase(22, 48, 33)]
        public void WhenClockIsContructedMinutesLightsForQuartersAreRed(int hours, int minutes, int seconds)
        {
            var quarterIndices = new[] { 2, 5, 8 };
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var toCheck =
                berlinClock
                    .ThirdRow
                    .Where((_, index) => quarterIndices.Contains(index));

            Assert.That(toCheck, Has.Exactly(3).RedLights());
        }

        [TestCase(00, 00, 00)]
        [TestCase(06, 06, 06)]
        [TestCase(10, 16, 10)]
        [TestCase(15, 25, 15)]
        [TestCase(21, 40, 21)]
        [TestCase(22, 48, 33)]
        public void WhenClockIsContructedMinutesLightsInLastRowAreYellow(int hours, int minutes, int seconds)
        {
            var berlinClock = new BerlinClock(new Time(hours, minutes, seconds));
            var row = berlinClock.FourthRow;

            Assert.That(row, Has.Exactly(4).YellowLights());
        }
    }

    internal static class AssertExtensions
    {
        public static NUnit.Framework.Constraints.Constraint YellowLights(this NUnit.Framework.Constraints.ItemsConstraintExpression expr)
        {
            return expr.Matches<Light>(l => l.Color == Color.Yellow);
        }

        public static NUnit.Framework.Constraints.Constraint RedLights(this NUnit.Framework.Constraints.ItemsConstraintExpression expr)
        {
            return expr.Matches<Light>(l => l.Color == Color.Red);
        }

        public static NUnit.Framework.Constraints.Constraint LightsOn(this NUnit.Framework.Constraints.ItemsConstraintExpression expr)
        {
            return expr.Matches<Light>(l => l.IsOn);
        }

        public static NUnit.Framework.Constraints.Constraint LightsOff(this NUnit.Framework.Constraints.ItemsConstraintExpression expr)
        {
            return expr.Matches<Light>(l => !l.IsOn);
        }
    }
}
