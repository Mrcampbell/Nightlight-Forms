using Nightlight.BridgeClasses;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Nightlight.Attributes
{
    public class NightlightStringAttribute : NightlightBaseAttribute, INightlightStringBridge
    {
        private int _minLength;
        private bool _minLengthIsSet;

        private int _maxLength;
        private bool _maxLengthIsSet;

        public NightlightStringAttribute(string Title) : base(Title)
        {
            _minLengthIsSet = false;
            _maxLengthIsSet = false;
        }

        public delegate void SetterDelegate(string newValue);

        public bool Required { get; set; }

        public int MinLength { get => _minLength; set { _minLength = value; _minLengthIsSet = true; } }
        public bool MinLengthIsSet { get => _minLengthIsSet; }

        public int MaxLength { get=> _maxLength; set { _maxLength = value; _maxLengthIsSet = true; } }
        public bool MaxLengthIsSet { get => _maxLengthIsSet; }

        // TODO: This shouldn't be held by the attribute, but not sure currently how/where to store it
        public string Value { get; set; }

        // to be continued...
        //public string RegexPattern { get; set; }
    }
}
