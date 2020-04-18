using System;
using System.Linq;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string aTime)
        {
            if (IsEven(aTime.ToCharArray().Last()))
                return "Y";

            return "O";
        }

        private bool IsEven(char digit)
        {
            return int.Parse(digit.ToString()) % 2 == 0;
        }
    }
}
