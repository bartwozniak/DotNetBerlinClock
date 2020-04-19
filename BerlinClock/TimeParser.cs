using System;
using BerlinClock;

public class TimeParser : ITimeParser
{
    public Time Parse(string testString)
    {
        return new Time(1, 1, 1);
    }
}