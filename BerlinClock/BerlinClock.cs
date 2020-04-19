using System;
using System.Collections.Generic;

namespace BerlinClock
{
    public class BerlinClock
    {
        public Light SecondsLight { get; }
        public IReadOnlyList<Light> FirstRow { get; }
        public IReadOnlyList<Light> SecondRow { get; }
        public IReadOnlyList<Light> ThirdRow { get; }
        public IReadOnlyList<Light> FourthRow { get; }

        public BerlinClock(Light secondsLight,
            IReadOnlyList<Light> firstRow,
            IReadOnlyList<Light> secondRow,
            IReadOnlyList<Light> thirdRow,
            IReadOnlyList<Light> fourthRow)
        {
            SecondsLight = secondsLight;
            FirstRow  = firstRow  ?? throw new ArgumentNullException(nameof(firstRow));
            SecondRow = secondRow ?? throw new ArgumentNullException(nameof(secondRow));
            ThirdRow  = thirdRow  ?? throw new ArgumentNullException(nameof(thirdRow));
            FourthRow = fourthRow ?? throw new ArgumentNullException(nameof(fourthRow));
        }
    }
}
