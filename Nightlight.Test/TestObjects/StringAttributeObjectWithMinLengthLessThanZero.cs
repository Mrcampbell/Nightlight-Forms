using Nightlight.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightlight.Test.TestObjects
{
    public class StringAttributeObjectWithMinLengthLessThanZero
    {
        [NightlightString("Test", MinLength = -1)]
        public string Field { get; set; }
    }
}
