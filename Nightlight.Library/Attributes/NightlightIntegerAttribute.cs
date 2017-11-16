using Nightlight.BridgeInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.Attributes
{
    public class NightlightIntegerAttribute : NightlightBaseAttribute, INightlightIntegerBridge
    {
        private int _minValue;

        private int _maxValue;

        public NightlightIntegerAttribute(string Title) : base(Title)
        {
            _minValue = int.MinValue;
            _maxValue = int.MaxValue;
            Required = false;
        }

        public bool Required { get; set; }
        public int MinValue
        {
            get => _minValue;
            set => _minValue = value;
        }

        public int MaxValue
        {
            get => _maxValue;
            set => _maxValue = value;
        }


        public bool MustBePositive { get; set; }
        public int Value { get; set; }
    }
}
