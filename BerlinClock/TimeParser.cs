using System;
using BerlinClock;

public class TimeParser : ITimeParser
{
    public Time Parse(string testString)
    {
        var components = testString.Split(':');
        var hour = int.Parse(components[0]);
        var minute = int.Parse(components[1]);
        var second = int.Parse(components[2]);

        return new Time(hour, minute, second);
    }
}