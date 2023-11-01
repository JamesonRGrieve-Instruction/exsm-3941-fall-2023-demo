namespace CSharpConsoleApp
{
    internal class Program
    {
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

                if (operation == "+")
                {
                    Console.WriteLine("The solution to " + leftOperand + " + " + rightOperand + " is " + (leftOperand + rightOperand));
                }
                else if (operation == "-")
                {
                    Console.WriteLine("The solution to " + leftOperand + " - " + rightOperand + " is " + (leftOperand - rightOperand));
                }
                else if (operation == "*")
                {
                    Console.WriteLine("The solution to " + leftOperand + " * " + rightOperand + " is " + (leftOperand * rightOperand));
                }
                else if (operation == "/")
                {
                    Console.WriteLine("The solution to " + leftOperand + " / " + rightOperand + " is " + (leftOperand / rightOperand));
                }
                else if (operation == "%")
                {
                    Console.WriteLine("The solution to " + leftOperand + " / " + rightOperand + " is " + (leftOperand % rightOperand));
                }
                else
                {
                    Console.WriteLine("Your provided operator is invalid. Sorry. Please try again.");
                }
            } while (operation != "+" && operation != "-" && operation != "/" && operation != "*" && operation != "%");
            

        }
    }
}