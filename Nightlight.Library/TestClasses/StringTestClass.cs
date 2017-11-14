using System;
using System.Collections.Generic;
using System.Text;
using Nightlight.Attributes;

namespace Nightlight.TestClasses
{
    public class StringTestClass
    {
        [NightlightString(Title: "Hello Title!", MinLength = 3)]
        public string Name { get; set; }

    }
}
