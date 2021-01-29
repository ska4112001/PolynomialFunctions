using Polynomial.Infrastructure.Shared.Processes;
using Polynomial.Infrastructure.Shared.Util;
using Polynomial.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Please input points in x y representation [Type END to Finish]");
            Menu();
            Console.ReadLine();
        }

        private static void Menu()
        {
            var strUserInput = "";
            var counter = 1;
            do
            {
                Console.WriteLine($"P#{counter} : ");
                Console.SetCursorPosition(9, counter);
                var input = Console.ReadLine();
                counter += 1;
                strUserInput += input + Environment.NewLine;
            } while (!strUserInput.ToUpper().Contains("END"));

            var userInput = strUserInput?.ToUpper().Split("END");
            List<string> coeffecientList;
            if (ValidateUserInput(userInput[0]))
            {
                var equations = userInput[0];

                var buffer = equations.Split(Environment.NewLine);
                Console.WriteLine($"Resulting Polynomial will be of the order {buffer.Length - 2}");
                var coefficients = "";
                var constants = "";
                for (int i = 0; i < buffer.Length; i++)
                {
                    coeffecientList = new List<string>();
                    if (string.IsNullOrWhiteSpace(buffer[i])) continue;
                    constants += buffer[i].Split(" ").Last() + Environment.NewLine;
                    var num = buffer[i].Split(" ").SkipLast(1).Last();
                    coeffecientList.Add(Math.Pow(Double.Parse(num), 2).ToString());
                    coeffecientList.Add(num);
                    coeffecientList.Add("1");
                    coefficients += string.Join(" ", coeffecientList) + Environment.NewLine;
                }

                var contextHandler = new ContextHandler();
                contextHandler.AugmentedMatrix = Matrix.CreateAugmentedMAtrix(coefficients, constants);
                var backwardElimininationHandler = new BackwardEliminationHandler();
                var checkIfThereIsSolutionHandler = new CheckIfSolutionHandler();
                var forwardEliminationHandler = new FowardEliminationHandler();
                var printResultsHandler = new PrintResultsHandler();
                var calculatePolyPointValues = new CalculatePolyPointValuesHandler();
                var calculateDerivativeHandler = new CalculateDerivativeHandler();
                var newtonHandler = new NewtonHandler();
                forwardEliminationHandler
                    .SetNext(checkIfThereIsSolutionHandler)
                    .SetNext(backwardElimininationHandler)
                    .SetNext(calculatePolyPointValues)
                    .SetNext(calculateDerivativeHandler)
                    .SetNext(newtonHandler)
                    .SetNext(printResultsHandler);
                forwardEliminationHandler.Handle(contextHandler);

            }
        }

        private static bool ValidateUserInput(string userInput)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Input can not be Empty");
                    return false;
                }

                userInput = userInput?.Replace(" ", "");
                userInput = userInput?.Replace(Environment.NewLine, "");
                userInput = userInput?.Replace("+", "").Replace("-", "").Replace(".", "");
                if (!Util.IsNumeric(userInput))
                {
                    Console.WriteLine("Points Includes Non Numeric Values");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
                return false;
            }
        }
    }
}
