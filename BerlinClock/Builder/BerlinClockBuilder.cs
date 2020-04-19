using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BerlinClock.UnitTests")]
namespace BerlinClock.Builder
{
    internal sealed class BerlinClockBuilder
    {
        private readonly Time _time;

        internal BerlinClockBuilder(Time time)
        {
            _time = time;
        }

        internal BerlinClock Build()
        {
            return new BerlinClock(
                MakeSecondsLight(),
                MakeFirstRow(),
                MakeSecondRow(),
                MakeThirdRow(),
                MakeFourthRow());
        }

        private Light MakeSecondsLight()
        {
            if (IsEven(_time.Second))
                return new Light(true, Color.Yellow);

            return new Light(false, Color.Yellow);

            bool IsEven(int digit)
            {
                return digit % 2 == 0;
            }
        }

        private IEnumerable<Light> MakeFirstRow()
        {
            var onCount = _time.Hour / 5;
            var row =
                new RowBuilder()
                    .WithLights(4)
                    .OfColor(Color.Red)
                    .SwichOn(onCount)
                    .Build();

            return row;
        }

        private IEnumerable<Light> MakeSecondRow()
        {
            var onCount = _time.Hour % 5;
            var row =
                new RowBuilder()
                    .WithLights(4)
                    .OfColor(Color.Red)
                    .SwichOn(onCount)
                    .Build();

            return row;
        }

        private IEnumerable<Light> MakeThirdRow()
        {
            var onCount = _time.Minute / 5;
            var qarterIndices = new int[] { 2, 5, 8 };
            var row =
                new RowBuilder()
                    .WithLights(11)
                    .OfAlternatingColors(idx => qarterIndices.Contains(idx) ? Color.Red : Color.Yellow)
                    .SwichOn(onCount)
                    .Build();

            return row;
        }

        private IEnumerable<Light> MakeFourthRow()
        {
            var onCount = _time.Minute % 5;
            var row =
                new RowBuilder()
                    .WithLights(4)
                    .OfColor(Color.Yellow)
                    .SwichOn(onCount)
                    .Build();

            return row;
        }
    }
}
