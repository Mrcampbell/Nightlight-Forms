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
        static void Main(string[] args)
        {
            StringClassForTestingValues stc = new StringClassForTestingValues
            {
            };

            NightlightFormController<StringClassForTestingValues> controller = new NightlightFormController<StringClassForTestingValues>(stc);

            NightlightConsoleForm<StringClassForTestingValues> consoleForm = new NightlightConsoleForm<StringClassForTestingValues>(controller);

            consoleForm.Run();

            Console.ReadKey(true);

        }
    }
}
