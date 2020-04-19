using System;
using System.Collections.Generic;

namespace BerlinClock
{
    public class BerlinClock
    {
        public Light SecondsLight { get; }
        public IEnumerable<Light> FirstRow { get; }
        public IEnumerable<Light> SecondRow { get; }
        public IEnumerable<Light> ThirdRow { get; }
        public IEnumerable<Light> FourthRow { get; }

        public BerlinClock(Light secondsLight, IEnumerable<Light> firstRow, IEnumerable<Light> secondRow, IEnumerable<Light> thirdRow, IEnumerable<Light> fourthRow)
        {
            SecondsLight = secondsLight;
            FirstRow = firstRow ?? throw new ArgumentNullException(nameof(firstRow));
            SecondRow = secondRow ?? throw new ArgumentNullException(nameof(secondRow));
            ThirdRow = thirdRow ?? throw new ArgumentNullException(nameof(thirdRow));
            FourthRow = fourthRow ?? throw new ArgumentNullException(nameof(fourthRow));
        }
    }
}
