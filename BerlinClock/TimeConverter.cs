using BerlinClock.Builder;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string aTime)
        {
            var time = new SimpleTimeParser().Parse(aTime);
            var clock = new BerlinClockBuilder(time).Build();
            var formatter = new StringFormatter();

            return formatter.Format(clock);
        }
    }
}
