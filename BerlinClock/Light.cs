﻿namespace BerlinClock
{
    public readonly struct Light
    {
        public bool IsOn { get; }
        public Color Color { get; }

        public Light(bool isOn, Color color)
        {
            IsOn = isOn;
            Color = color;
        }
    }
}
