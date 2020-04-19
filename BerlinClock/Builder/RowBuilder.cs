using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock.Builder
{
    internal sealed class RowBuilder : IChooseColorRowBuilder, IChooseNumberOnRowBuilder, IReadyRowBuilder
    {
        private int _count;
        private int _onCount;
        private Func<int, Color> _colorSelector;

        public RowBuilder() {
            _count = 0;
            _onCount = 0;
            _colorSelector = _ => default;
        }

        public IChooseColorRowBuilder WithLights(int count)
        {
            _count = count;
            return this;
        }

        IChooseNumberOnRowBuilder IChooseColorRowBuilder.OfAlternatingColors(Func<int, Color> colorSelector)
        {
            _colorSelector = colorSelector;
            return this;
        }

        IChooseNumberOnRowBuilder IChooseColorRowBuilder.OfColor(Color color)
        {
            _colorSelector = _ => color;
            return this;
        }

        IReadyRowBuilder IChooseNumberOnRowBuilder.SwichOn(int onCount)
        {
            _onCount = onCount;
            return this;
        }

        IEnumerable<Light> IReadyRowBuilder.Build()
        {
            return MakeLights(_onCount, _count, _colorSelector);
        }

        private static IList<Light> MakeLights(int onCount, int lightsCount, Func<int, Color> colorSelector)
        {
            var lightsOn = InitLights(true, colorSelector, 0, onCount);
            var lightsOff = InitLights(false, colorSelector, onCount, lightsCount);

            return lightsOn.Concat(lightsOff).ToList();

            IEnumerable<Light> InitLights(bool value, Func<int, Color> colorSelector, int startIndex, int endIndex)
            {
                for (int i = startIndex; i < endIndex; ++i)
                    yield return new Light(value, colorSelector(i));
            }
        }
    }

    internal interface IChooseColorRowBuilder
    {
        IChooseNumberOnRowBuilder OfColor(Color color);
        IChooseNumberOnRowBuilder OfAlternatingColors(Func<int, Color> colorSelector);
    }

    internal interface IChooseNumberOnRowBuilder
    {
        IReadyRowBuilder SwichOn(int onCount);
    }

    internal interface IReadyRowBuilder
    {
        IEnumerable<Light> Build();
    }
}
