﻿namespace BerlinClock.Lights
{
    public struct Light
    {
        public bool IsOn { get; }
        public Color Color { get; set; }

        public Light(bool isOn, Color color)
        {
            IsOn = isOn;
            Color = color;
        }
    }
}
