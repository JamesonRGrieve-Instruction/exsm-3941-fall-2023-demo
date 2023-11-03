using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    internal class Program
    {
        enum Month : byte
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December,
            Spring = 101,
            Summer,
            Autumn,
            Winter
        }
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
        static Month GetValidInt(string prompt)
        {
            Month userResponse = 0;
            do
            {
                Console.Write(prompt);
            } while (!Month.TryParse(Console.ReadLine(), out userResponse));
            return userResponse;
        }
        static void CountTo(int to, int count)
        {
            if (count <= to)
            {
                Console.WriteLine(count);
                CountTo(to, count + 1);
            }
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


            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            CountTo(10, 1);

            int leftOperand, rightOperand;
            leftOperand = (int)GetValidInt("Please enter a left operand (number): ");
            rightOperand = (int)GetValidInt("Please enter a right operand (number): ");
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