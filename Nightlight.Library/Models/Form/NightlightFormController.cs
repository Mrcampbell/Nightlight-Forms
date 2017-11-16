using Nightlight.Models.Nodes;
using Nightlight.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nightlight.Models.Form
{
    public class NightlightFormController<T>
    {
        public IEnumerable<INightlightNode> Nodes { get; set; }
        
        public bool AllFieldsValid { get; set; }

        public NightlightFormController(T obj)
        {
            var attributes = AttributeUtils.ReadAttributes(obj);

            Nodes = AttributeUtils.GetNodesFromAttributes(attributes);

            // validate all the nodes.  I did it here arbitrarily, thinking
            // that validation at build, rather on the node creation,
            // would hide the contents of the library
            foreach(var node in Nodes)
            {
                node.ValidateNode();
            }
        }
    }
}
