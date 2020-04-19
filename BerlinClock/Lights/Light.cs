namespace BerlinClock.Lights
{
    public struct Light
    {
        public bool IsOn { get; }

        public Light(bool isOn)
        {
            IsOn = isOn;
        }

        public static Light On  => new Light(true);
        public static Light Off => new Light(false);
    }
}
