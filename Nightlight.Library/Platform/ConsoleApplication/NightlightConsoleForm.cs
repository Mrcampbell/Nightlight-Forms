using Nightlight.Models.Form;
using Nightlight.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.Platform.ConsoleApplication
{
    public class NightlightConsoleForm<T>
    {
        public NightlightFormController<T> Controller { get; }

        public NightlightConsoleForm(NightlightFormController<T> controller)
        {
            Controller = controller;
        }

        private bool _getInputForNode(INightlightNode node)
        {
            // TODO: Consolidate functions
            if (node is NightlightStringNode stringNode)
            {
                // spacer
                Console.WriteLine();

                // display prompt
                Console.WriteLine(stringNode.Title + " (String)");

                // provide previous value (if one exists)
                if (!String.IsNullOrWhiteSpace(node.GetValueString()))
                    Console.WriteLine($"(Previous Value: {node.GetValueString()})");

                Console.Write("> ");

                string input = Console.ReadLine();

                stringNode.Value = input;

                if (!stringNode.IsValid())
                {
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(stringNode.GetErrorMessage());
                    Console.BackgroundColor = ConsoleColor.Black;

                    return false;
                }

                stringNode.Value = input;

            }
            else if (node is NightlightIntegerNode intNode)
            {
                // spacer
                Console.WriteLine();

                // display prompt
                Console.WriteLine(intNode.Title + " (Integer)");

                // provide previous value (if one exists)
                if (!String.IsNullOrWhiteSpace(node.GetValueString()))
                    Console.WriteLine($"(Previous Value: {node.GetValueString()})");

                Console.Write("> ");

                string inputString = Console.ReadLine();

                bool hasParsed = int.TryParse(inputString, out int inputInteger) || !intNode.Required;

                if (!hasParsed || !intNode.IsValid())
                {
                    Console.WriteLine();

                    if (!hasParsed)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unsuccessful Parse");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(intNode.GetErrorMessage());
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    return false;
                }

                intNode.Value = inputInteger;
            }


            return true;
        }

        public void Run()
        {
            Console.WriteLine("\n\nBeginning of Console Form: ___________________________");
            foreach(var node in Controller.Nodes)
            {
                bool success = false;

                while (!success)
                {
                    success = _getInputForNode(node);

                    if (success)
                    {
                        Console.WriteLine($"(Successful Validation: {node.GetValueString()})");
                    }
                }
            }

            Console.WriteLine("\n\nEnd of Form ___________________________");
        }

    }
}
