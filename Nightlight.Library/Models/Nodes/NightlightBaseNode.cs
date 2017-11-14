using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.Models.Nodes
{
    public class NightlightBaseNode : INightlightNode
    {
        private string _title;

        public NightlightBaseNode()
        {

        }

        public string Title { get => _title; }
    }
}
