using System;
using System.Collections.Generic;
using System.Text;
using BerlinClock.Lights;

namespace BerlinClock
{
    public class StringFormatter : IBerlinClockFormatter<string>
    {
        public string Format(BerlinClock clock)
        {
            var seconds = Format(clock.SecondsLight);
            var topHours = Format(clock.FirstRow);
            var bottomHours = Format(clock.SecondRow);
            return $"{seconds}\n{topHours}\n{bottomHours}\n\n";
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

            return FirstLetter(light.Color);
        }

        private string FirstLetter(Color color)
        {
            var enumString = color.ToString();
            return enumString[0].ToString();
        }
    }
}