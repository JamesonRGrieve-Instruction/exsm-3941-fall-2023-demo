namespace CSharpConsoleApp
{
    internal class Program
    {
        static int? EvaluateMath(int left, int right, string operation)
        {
            int? solution = null;
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
                solution = left / right;
            }
            else if (operation == "%")
            {
                solution = left % right;
            }
            return solution;
        }
        static int GetValidInt(string prompt)
        {
            int userResponse = 0;
            do
            {
                Console.Write(prompt);
                try
                { 
                    userResponse = int.Parse(Console.ReadLine());
                }
                catch { }
            } while (userResponse == 0);
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
            Console.Write("Please enter a left operand (number): ");
            try
            {
                leftOperand = int.Parse(Console.ReadLine());
            }
            catch (Exception ex) 
            {
                Console.WriteLine("ERROR: " + ex.Message);
                leftOperand = 10;
            }
            Console.Write("Please enter a right operand (number): ");
            rightOperand = Convert.ToInt32(Console.ReadLine());
            string operation;
            int badInputs = 0;
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
                    Console.WriteLine("Your solution is " + EvaluateMath(leftOperand, rightOperand, operation));
                }
            } while (operation != "+" && operation != "-" && operation != "/" && operation != "*" && operation != "%");
            Console.WriteLine("You entered a bad input " + badInputs + " times.");
        }
    }
}