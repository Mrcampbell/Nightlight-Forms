using System;
using System.Collections.Generic;
using System.Text;
using Nightlight.Attributes;

namespace Nightlight.TestClasses
{
    public class StringClassForTestingValues
    {


        [NightlightString(Title: "Required String With No Previous Value", Required = true)]
        public string RequiredStringWithNoPreviousValue { get; set; }

        private string _requiredStringWithPreviousValue_old = "Old Value";

        [NightlightString(Title: "Required String With Previous Value", Required = true)]
        public string RequiredStringWithPreviousValue
        {
            get => _requiredStringWithPreviousValue_old;
            set => _requiredStringWithPreviousValue_old = value;
        }

        [NightlightString(Title: "String with MinLength: 3", MinLength = 3)]
        public string StringWithMinLengthThree { get; set; }

        [NightlightString(Title: "String with MaxLength: 3", MaxLength = 3)]
        public string StringWithMaxLengthThree { get; set; }

        [NightlightString(Title: "String with MinLength: 3, MaxLength: 5", MinLength = 3, MaxLength = 5)]
        public string StringWithMinLengthThreeMaxLength5 { get; set; }

    }
}
