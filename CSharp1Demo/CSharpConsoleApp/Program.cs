﻿namespace CSharpConsoleApp
{
    internal class Program
    {

        static void Add3ToInteger(ref decimal value)
        {
            value += 3;
        }
        static decimal? EvaluateMath(int left, int right, string operation)
        {
            decimal? solution = null;
            try
            {
                if (operation == "+")
                {
                    solution = left + right;
                }
                else if (operation == "-")
                {
                    solution = left - right;
                }
                else if (operation == "*")
                {
                    solution = left * right;
                }
                else if (operation == "/")
                {
                    solution = (decimal)left / (decimal)right;
                }
                else if (operation == "%")
                {
                    solution = left % right;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            return solution;
        }

        /// <summary>
        /// Prompt the user repeatedly to provide a valid integer using the prompt provided, until they do so.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <returns>The valid integer once the user provides one.</returns>
        static int GetValidInt(string prompt)
        {
            int userResponse = 0;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out userResponse));
            return userResponse;
        }
        static void Main(string[] args)
        {
            // --- Data Types ---
            // Integer Numeric Data Types
            int userNumber;
            short userShort;
            long userLong;

            // Floating Point Numeric Data
            float userFloat;
            double userDouble;

            // Decimal Numeric Data
            decimal userDecimal;

            // Character/String Data
            char userChar;
            string userName;

            // Boolean Data
            bool userBool;

            // -- Operators --
            // Arithmetic Operators
            // + - * / %

            // Relational Operators
            // > < >= <= == !=

            // Logical Operators
            // && || !


            int leftOperand, rightOperand;
            leftOperand = GetValidInt("Please enter a left operand (number): ");
            rightOperand = GetValidInt("Please enter a right operand (number): ");
            string operation;
            int badInputs = 0;
            decimal result = 0;
            do
            {
                Console.Write("Please enter a operator (+ - / * %): ");
                operation = Console.ReadLine();
                if (operation != "+" && operation != "-" && operation != "/" && operation != "*" && operation != "%")
                {
                    Console.WriteLine("Your provided operator is invalid. Sorry. Please try again.");
                    badInputs++;
                }
                else
                {
                    result = EvaluateMath(leftOperand, rightOperand, operation)??0;
                    Console.WriteLine($"Your solution is {result:0.00}.");
                }
            } while (operation != "+" && operation != "-" && operation != "/" && operation != "*" && operation != "%");
            Console.WriteLine("You entered a bad input " + badInputs + " times.");

            Add3ToInteger(ref result);
            Console.WriteLine("If we add 3 to the result, we get: " + result);
        }
    }
}