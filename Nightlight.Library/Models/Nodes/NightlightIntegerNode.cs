using Nightlight.BridgeInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.Models.Nodes
{
    class NightlightIntegerNode : NightlightBaseNode, INightlightIntegerBridge
    {
        public NightlightIntegerNode(string Title) : base(Title)
        {

        }

        public bool Required { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public bool MustBePositive { get; set; }
        public int Value { get; set; }

        public override string GetErrorMessage()
        {
            return String.Empty;
        }

        public override string GetValueString()
        {
            return Value.ToString();
        }

        public override bool IsValid()
        {
            return String.IsNullOrWhiteSpace(GetErrorMessage());
        }

        public override void ValidateNode()
        {
            
        }
    }
}
