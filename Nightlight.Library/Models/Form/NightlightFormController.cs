using Nightlight.Models.Nodes;
using Nightlight.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Android.Util;
using Nightlight.TestClasses;

namespace Nightlight.Models.Form
{
    public class NightlightFormController<T>
    {
        public IEnumerable<INightlightNode> Nodes { get; set; }
        
        public bool AllFieldsValid { get; set; }

        public NightlightFormController(ref T obj)
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

        public void UpdateObject(ref T updatedObject)
        {
            foreach (var node in Nodes)
            {
                var stringNode = node as NightlightStringNode;
                PropertyInfo prop = updatedObject.GetType().GetProperty(stringNode.PropertyName, BindingFlags.Public | BindingFlags.Instance);

                if (stringNode.Value == null)
                {
                    stringNode.Value = String.Empty;
                }

                if (prop != null && prop.CanWrite)
                {
                    Log.Debug("Found prop: " + prop.Name, "Value: " + stringNode.GetValueString());
                    if (prop.Name == stringNode.PropertyName)
                    {

                        prop.SetValue(updatedObject, stringNode.Value);
                    }
                }
            }
        }

        public T GetUpdatedObject()
        {
            T output = (T)Activator.CreateInstance(typeof(T));

            foreach (var node in Nodes)
            {
                var stringNode = node as NightlightStringNode;

                PropertyInfo prop = output.GetType().GetProperty(stringNode.PropertyName, BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && prop.CanWrite)
                {
                    Log.Debug("Found Prop: " + prop.Name, "Value: " + stringNode.GetValueString());

                    string readValue = prop.GetValue(output, null) as string;

                    if (readValue == null)
                    {
                        readValue = String.Empty;
                    }

                    prop.SetValue(output, readValue, null);

                    Log.Debug("PROP: ", readValue);
                }
            }

            StringClassForTestingValues testClass = output as StringClassForTestingValues;

            Log.Debug("First: ", testClass.RequiredStringWithNoPreviousValue);

            return output;
        }
    }
}
