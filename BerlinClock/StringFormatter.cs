using System;
using System.Collections.Generic;
using System.Text;

namespace BerlinClock
{
    public class StringFormatter : IBerlinClockFormatter<string>
    {
        public string Format(BerlinClock clock)
        {
            var seconds = Format(clock.SecondsLight);
            var topHours = Format(clock.FirstRow);
            var bottomHours = Format(clock.SecondRow);
            var topMinutes = Format(clock.ThirdRow);
            var bottomMinutes = Format(clock.FourthRow);

            return string.Join(Environment.NewLine, seconds, topHours, bottomHours, topMinutes, bottomMinutes);
        }

        private string Format(IEnumerable<Light> row)
        {
            var sb = new StringBuilder();
            foreach(var light in row)
            {
                sb.Append(Format(light));
            }

            return sb.ToString();
        }

        private string Format(Light light)
        {
            if (!light.IsOn)
                return "O";

            return FirstLetterOf(light.Color);
        }

        private string FirstLetterOf(Color color)
        {
            var enumString = color.ToString();
            return enumString[0].ToString();
        }
    }
}