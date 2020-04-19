namespace BerlinClock
{
    public interface IBerlinClockFormatter<T>
    {
        T Format(BerlinClock clock);
    }
}