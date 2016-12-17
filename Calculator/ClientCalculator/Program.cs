using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ClientCalculator.CalculatorService;

namespace ClientCalculator
{
    class Program
    {
        static CalculatorClient client = new CalculatorClient();

        static void Main(string[] args)
        {
            var isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Type your command here");
                var command = Console.ReadLine();

                if (command != null)
                    switch (command.ToLower())
                    {
                        case "add":
                            CallOperations(Operations.Add);
                            break;
                        case "substract":
                            CallOperations(Operations.Substact);
                            break;
                        case "multiply":
                            CallOperations(Operations.Multiply);
                            break;
                        case "divide":
                            CallOperations(Operations.Divide);
                            break;
                        case "sqrt":
                            CallSqrt();
                            break;
                        case "exit":
                            Console.WriteLine("Bye");
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Try againg");
                            break;
                    }
            }
            try
            {
                client.Close();
            }
            catch (CommunicationException)
            {
                client.Abort();
            }
        }



        private static void CallOperations(Operations operation)
        {
            Console.WriteLine("Enter 2 parameters");
            var firstArgument = Console.ReadLine();
            var secondArgument = Console.ReadLine();
            double first, second;
            if (double.TryParse(firstArgument, out first) && double.TryParse(secondArgument, out second))
            {
                try
                {
                    switch (operation)
                    {
                        case Operations.Add:
                            Console.WriteLine(client.Add(first, second));
                            break;
                        case Operations.Divide:
                            Console.WriteLine(client.Divide(first, second));
                            break;
                        case Operations.Multiply:
                            Console.WriteLine(client.Multiply(first, second));
                            break;
                        case Operations.Substact:
                            Console.WriteLine(client.Substract(first, second));
                            break;
                    }
                }
                catch (FaultException<ExecutionFaults> e)
                {
                    Console.WriteLine(e.Detail.Message);
                }
            }
            else
            {
                Console.WriteLine("Input Error, please try again");
            }
        }

        private static void CallSqrt()
        {
            Console.WriteLine("Enter parameter");
            var argument = Console.ReadLine();
            double doubleArgument;
            if (double.TryParse(argument, out doubleArgument))
            {
                try
                {
                    Console.WriteLine(client.Sqrt(doubleArgument));
                }
                catch (FaultException<ExecutionFaults> e)
                {
                    Console.WriteLine(e.Detail.Message);
                }
            }
            else
            {
                Console.WriteLine("Input Error, please try again");
            }
        }
    }
}
