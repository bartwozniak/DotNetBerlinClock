namespace BerlinClock.Lights
{
    public struct SecondsLight
    {
        public bool IsOn { get; }

        public SecondsLight(bool isOn)
        {
            IsOn = isOn;
        }

        public static SecondsLight On  => new SecondsLight(true);
        public static SecondsLight Off => new SecondsLight(false);
    }
}
