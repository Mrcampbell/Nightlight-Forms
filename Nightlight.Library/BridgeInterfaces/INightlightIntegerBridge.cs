using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.BridgeInterfaces
{
    public interface INightlightIntegerBridge
    {
        bool Required { get; set; }
        int MinValue { get; set; }
        int MaxValue { get; set; }
        bool MustBePositive { get; set; }
        int Value { get; set; }

        // to be continued...
        // int MustBeDivisibleBy { get; set; }
    }
}
