using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Two Dimmensional Arrays must be all the same length (# of rows and columns - must be a "rectangle").
            char[,] TicTacToe = {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            char[,] AnotherTicTacToe = new char[3, 3];

            // Nested Collections can be different lengths.
            List<char[]> chars = new List<char[]>
            {
                new char[] { ' ', ' ', ' ' },
                new char[] { ' ', ' ', ' ', ' ' },
                new char[] { ' ', ' ', ' ' }
            };
            List<string> names = new List<string>
            {
                "Joe Smith",
                "Sally Sue",
                "Bob Young"
            };
            names.RemoveAt(1);
            chars.RemoveAt(1);
            names.Add("John Doe");
            chars.Add(new char[] { ' ', ' ' });
            for (int i = 0 ; i < names.Count ; i++)
            {
                Console.WriteLine($"{names[i]} has {chars[i].Length} characters.");
            }

            // Dynamic Typed Lists - please don't do this, but it's technically possible.
            List<object> list = new List<object> { 
                1,
                "Hello",
                true
            };

            int myNumber = 0;
            foreach (object item in list)
            {
                if (item.GetType()  == typeof(int))
                {
                    myNumber += (int)item;
                }
            }
        }
        public static int GetValidInt(string prompt)
        {
            string input;
            Console.Write(prompt);
            input = Console.ReadLine().Trim().ToUpper();
            int parsedInput;
            while (!int.TryParse(input, out parsedInput))
            {
                Console.Write("Invalid input, please enter a integer (whole number) and try again: ");
                input = Console.ReadLine().Trim().ToUpper();
            }
            return parsedInput;
        }
    }
}
