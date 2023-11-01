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
            else
            {
                Console.WriteLine("Your provided operator is invalid. Sorry. Please try again.");
            }
            return solution;
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
            leftOperand = int.Parse(Console.ReadLine());
            Console.Write("Please enter a right operand (number): ");
            rightOperand = Convert.ToInt32(Console.ReadLine());
            string operation;
            do
            {
                Console.Write("Please enter a operator (+ - / * %): ");
                operation = Console.ReadLine();

                Console.WriteLine("You solution is "+EvaluateMath(leftOperand, rightOperand, operation));
            } while (operation != "+" && operation != "-" && operation != "/" && operation != "*" && operation != "%");
        }
    }
}