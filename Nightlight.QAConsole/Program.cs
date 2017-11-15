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
            StringTestClass stc = new StringTestClass
            {
            };

            NightlightFormController<StringTestClass> controller = new NightlightFormController<StringTestClass>(stc);

            NightlightConsoleForm<StringTestClass> consoleForm = new NightlightConsoleForm<StringTestClass>(controller);

            consoleForm.Run();

            Console.ReadKey(true);

        }
    }
}
