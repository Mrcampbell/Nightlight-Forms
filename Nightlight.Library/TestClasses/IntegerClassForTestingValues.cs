using Nightlight.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.TestClasses
{
    public class IntegerClassForTestingValues
    {
        [NightlightInteger(Title: "Integer")]
        public int? BasicInteger { get; set; }

        [NightlightInteger("Required Integer", Required = true)]
        public int RequiredInteger { get; set; }

        //[NightlightInteger("String Attribute Applied Erroneously to Integer")]
        //public int? IntegerNotAString { get; set; }
    }
}
