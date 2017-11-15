using Nightlight.Attributes;
using Nightlight.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nightlight.Services
{
    public static class AttributeUtils
    {
        public static IEnumerable<INightlightAttribute > ReadAttributes<T>(T obj)
        {
            //TODO: loosen this up so we can use an array rather than use processing power, etc
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<INightlightAttribute> attributes = new List<INightlightAttribute>();

            foreach (var property in properties)
            {
                foreach (object attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is NightlightBaseAttribute baseAttribute)
                    {
                        if (baseAttribute is NightlightStringAttribute stringAttribute)
                        {
                            Console.WriteLine("String attribute found!");
                            Console.WriteLine($"  Name of Property:  {property.Name}");
                            Console.WriteLine($"  Value of Property: {property.GetValue(obj, null)}");

                            Console.WriteLine($"  Title Provided:    {stringAttribute.Title}");
                            Console.WriteLine($"  MinLength:         {stringAttribute.MinLength}");
                            Console.WriteLine($"  MinLengthIsSet:    {stringAttribute.MinLengthIsSet}");
                            Console.WriteLine($"  MaxLength:         {stringAttribute.MaxLength}");
                            Console.WriteLine($"  Required:          {stringAttribute.Required}");

                            stringAttribute.Value = property.GetValue(obj, null) as string;

                            attributes.Add(stringAttribute);
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Undeclared Nightlight Attribute Found");
                        }
                    }
                }
            }
            return attributes;
        }

        public static IEnumerable<INightlightNode> GetNodesFromAttributes(IEnumerable<INightlightAttribute> attributes)
        {
            List<INightlightNode> nodes = new List<INightlightNode>();

            foreach (var attribute in attributes)
            {
                if (attribute is NightlightStringAttribute nsa)
                {
                    Console.WriteLine("Found NightlightStringAttribute");

                    // TODO: Extract Mapping
                    NightlightStringNode node = new NightlightStringNode(nsa.Title)
                    {
                        Required = nsa.Required
                    };

                    if (nsa.MinLengthIsSet)
                        node.MinLength = nsa.MinLength;

                    if (nsa.MaxLengthIsSet)
                        node.MaxLength = nsa.MaxLength;

                    node.Value = nsa.Value ?? null;

                    nodes.Add(node);
                }
            }

            return nodes;
        }
    }
}
