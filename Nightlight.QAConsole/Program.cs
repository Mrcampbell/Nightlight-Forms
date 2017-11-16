using Nightlight.Models.Form;
using Nightlight.Models.Nodes;
using Nightlight.Platform.ConsoleApplication;
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
        private static void TestStringClasses()
        {
            StringClassForTestingValues stc = new StringClassForTestingValues
            {
            };

            NightlightFormController<StringClassForTestingValues> controller = new NightlightFormController<StringClassForTestingValues>(stc);

            NightlightConsoleForm<StringClassForTestingValues> consoleForm = new NightlightConsoleForm<StringClassForTestingValues>(controller);

            consoleForm.Run();
        }

        private static void TestIntegerClasses()
        {
            IntegerClassForTestingValues itc = new IntegerClassForTestingValues
            {
            };

            NightlightFormController<IntegerClassForTestingValues> controller = new NightlightFormController<IntegerClassForTestingValues>(itc);

            NightlightConsoleForm<IntegerClassForTestingValues> consoleForm = new NightlightConsoleForm<IntegerClassForTestingValues>(controller);

            consoleForm.Run();
        }

        static void Main(string[] args)
        {
            TestIntegerClasses();

            Console.ReadKey(true);

        }
    }
}
