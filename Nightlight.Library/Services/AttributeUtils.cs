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

                            if (!property.PropertyType.Equals(typeof(string)))
                            {
                                throw new Exception("String attribute applied to Non-String Property");
                            }

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
                        else if (baseAttribute is NightlightIntegerAttribute intAttribute)
                        {
                            Console.WriteLine("Integer attribute found!");

                            Console.WriteLine(property.GetType());

                            if (property.PropertyType != typeof(int) && property.PropertyType != typeof(int?))
                            {
                                throw new Exception("Integer attribute applied to Non-Integer Property");
                            }

                            Console.WriteLine($"  Name of Property:  {property.Name}");
                            Console.WriteLine($"  Value of Property: {property.GetValue(obj, null)}");

                            Console.WriteLine($"  Title Provided:    {intAttribute.Title}");
                            Console.WriteLine($"  Minvalue:          {intAttribute.MinValue}");
                            Console.WriteLine($"  MaxValue:          {intAttribute.MaxValue}");
                            Console.WriteLine($"  MustBePositive:    {intAttribute.MustBePositive}");

                            int? value = (int?) property.GetValue(obj, null);

                            if (value != null)
                                intAttribute.Value = (int) value; 

                            attributes.Add(intAttribute);
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
                else if (attribute is NightlightIntegerAttribute nia)
                {
                    Console.WriteLine("Found NightlightIntegerAttribute");

                    // TODO: Extract Mapping
                    NightlightIntegerNode node = new NightlightIntegerNode(nia.Title)
                    {
                        Required = nia.Required
                    };

                    node.MinValue = nia.MinValue;
                    node.MaxValue = nia.MaxValue;
                    node.Value = nia.Value;
                    node.MustBePositive = nia.MustBePositive;

                    nodes.Add(node);
                }
            }

            return nodes;
        }
    }
}
