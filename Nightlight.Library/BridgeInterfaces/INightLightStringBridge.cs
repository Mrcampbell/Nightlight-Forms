using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.BridgeClasses
{
    public interface INightlightStringBridge
    {
        bool Required { get; set; }

        int MinLength { get; set;  }
        bool MinLengthIsSet { get; }

        int MaxLength { get; set; }
        bool MaxLengthIsSet { get; }

        string Value { get; set; }

        // to be continued...
        //string RegexPattern { get; set; }
    }
}
