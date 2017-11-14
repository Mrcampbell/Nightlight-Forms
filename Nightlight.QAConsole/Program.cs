using Nightlight.Services;
using Nightlight.TestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightlight.QAConsole
{

    class Program
    {
        static void Main(string[] args)
        {
            StringTestClass stc = new StringTestClass
            {
                Name = "Mike"
            };

            AttributeUtils.ReadAttributes(stc);

            Console.ReadKey(true);

        }
    }
}
