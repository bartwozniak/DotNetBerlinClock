using System;
using BerlinClock.Lights;

namespace BerlinClock
{
    public class StringFormatter : IBerlinClockFormatter<string>
    {
        public string Format(BerlinClock clock)
        {
            return $"{Format(clock.SecondsLight)}\n\n\n\n";
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