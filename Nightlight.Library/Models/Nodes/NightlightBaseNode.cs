using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.Models.Nodes
{
    public abstract class NightlightBaseNode : INightlightNode
    {
        private string _title;

        public NightlightBaseNode(string Title)
        {
            _title = Title;
        }

        public string Title { get => _title; }
        public abstract bool IsValid();
        public abstract string GetErrorMessage();

        // to be run on build to ensure there are no requirement conflicts
        public abstract void ValidateNode();

        public abstract string GetValueString();
    }
}
