using Nightlight.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nightlight.Services
{
    public static class AttributeUtils
    {
        public static IEnumerable<INightlightAttribute> ReadAttributes<T>(T obj)
        {
            //TODO: loosen this up so we can use an array rather than use processing power, etc
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<INightlightAttribute> attributes = new List<INightlightAttribute>();

            foreach (var property in properties)
            {
                foreach (object attribute in property.GetCustomAttributes(true))
                {
                    if (attribute is NightlightBaseAttribute nba)
                    {
                        if (nba is NightlightStringAttribute nsa)
                        {
                            Console.WriteLine("String attribute found!");
                            Console.WriteLine($"  Name of Property:  {property.Name}");
                            Console.WriteLine($"  Value of Property: {property.GetValue(obj, null)}");

                            Console.WriteLine($"  Title Provided:    {nsa.Title}");
                            Console.WriteLine($"  MinLength:         {nsa.MinLength}");
                            Console.WriteLine($"  MinLengthIsSet:    {nsa.MinLengthIsSet}");
                            Console.WriteLine($"  MaxLength:         {nsa.MaxLength}");
                            Console.WriteLine($"  Required:          {nsa.Required}");
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
    }
}
