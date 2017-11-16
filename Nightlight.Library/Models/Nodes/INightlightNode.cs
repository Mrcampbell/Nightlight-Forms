using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.Models.Nodes
{
    public interface INightlightNode
    {
        string GetValueString();
        void ValidateNode();
    }
}
