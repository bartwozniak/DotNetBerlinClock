using System;
using BerlinClock;

public class SimpleTimeParser : ITimeParser
{
    public Time Parse(string aTime)
    {
        if (aTime == null)
            throw new ArgumentException("Argument must not be null.", nameof(aTime));

        var components = aTime.Split(':');
        if (components.Length != 3)
            throw new FormatException($"Argument in incorrect format. Expected format is hh:mm:ss. Given: {aTime}.");

        var hour = int.Parse(components[0]);
        var minute = int.Parse(components[1]);
        var second = int.Parse(components[2]);

        return new Time(hour, minute, second);
    }
}