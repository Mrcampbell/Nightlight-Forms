using Nightlight.BridgeClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.Models.Nodes
{
    public class NightlightStringNode : NightlightBaseNode, INightlightStringBridge
    {
        private int _minLength;
        private bool _minLengthIsSet;

        private int _maxLength;
        private bool _maxLengthIsSet;

        public NightlightStringNode(string Title) : base (Title)
        {
            Required = false;
            _minLengthIsSet = false;
            _maxLengthIsSet = false;
        }

        public bool Required { get; set; }

        public int MinLength { get => _minLength; set { _minLength = value; _minLengthIsSet = true; Required = true; } }
        public bool MinLengthIsSet { get => _minLengthIsSet; }

        public int MaxLength { get => _maxLength; set { _maxLength = value; _maxLengthIsSet = true; } }
        public bool MaxLengthIsSet { get => _maxLengthIsSet; }

        public string Value { get; set; }

        // to be continued...
        //public string RegexPattern { get; set; }

        public override string GetValueString()
        {
            return Value;
        }

        public override string GetErrorMessage()
        {
            if (Required && String.IsNullOrWhiteSpace(Value))
                return "Field is Required";

            if (_minLengthIsSet && Value.Length < _minLength)
                return $"Entry is Too Short (Min Length: {_minLength})";

            if (_maxLengthIsSet && Value.Length > _maxLength)
                return $"Entry is Too Long (Max Length: {_maxLength})";

            return String.Empty;
        }

        public override bool IsValid()
        {
            return GetErrorMessage().Equals(String.Empty);
        }

        public override void ValidateNode()
        {
            if (_minLengthIsSet && _minLength == 0)
                throw new Exception($"Node: {Title} - Cannot have a Minimum Length of Zero.  Set Required Equal to True Instead");

            if (_minLength < 0)
                throw new Exception($"Node: {Title} - Cannot have a Minimum Length Less than Zero.  Minimum Length Provided: {_minLength}");

            if (_maxLength < 0)
                throw new Exception($"Node: {Title} - Cannot have a Maximum Length Less than Zero.  Maximum Length Provided: {_maxLength}");

            if (_minLengthIsSet && !Required)
                throw new Exception($"Node {Title} - Cannot have Required set to False with Minimum Length Greater than Zero");

            if (_minLengthIsSet && _maxLengthIsSet && _minLength >= _maxLength)
                throw new Exception($"Node: {Title} - Cannot have Minimum Length Greater Than or Equal to Maximum Length");
        }

        
    }
}
