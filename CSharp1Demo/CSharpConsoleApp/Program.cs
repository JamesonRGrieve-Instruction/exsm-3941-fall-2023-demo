using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Max length of 2.
            string[] stringArray =
            {
                "Hello",
                "World"
            };

            // Max length of 10 (default values - null).
            string[] emptyArray = new string[10];

            // Null.
            string emptyString;

            // Max length of 10 (default values - 0).
            int[] emptyIntArray = new int[10];

            // 0.
            int emptyInt;

            // Using physical and logical sizes.
            int[] numberArray = new int[10];
            int numberArrayLogicalSize = 0;

            string userInput = "";
            do
            {
                Console.Write("Please enter a number to store, 'VIEW' to view the numbers or 'QUIT' to quit.");
                userInput = Console.ReadLine().ToUpper().Trim();
                int parsed = 0;
                if (int.TryParse(userInput, out parsed))
                {
                    // Add to the array.
                    // Make sure the array isn't full.
                    if (numberArrayLogicalSize < numberArray.Length)
                    {
                        numberArray[numberArrayLogicalSize] = parsed;
                        numberArrayLogicalSize++;
                    }
                    else
                    {
                        Console.WriteLine("Array is full, sorry!");
                    }
                }
                else
                {
                    // Deal with "Commands".
                    if (userInput != "VIEW" && userInput != "QUIT")
                    {
                        Console.WriteLine("Invalid input, please try again.");
                    }
                    else if (userInput == "VIEW")
                    {
                        for (int i = 0; i < numberArrayLogicalSize; i++)
                        {
                            Console.WriteLine($"{i+1}) {numberArray[i]}");
                        }
                    }
                }
            } while (userInput != "QUIT");
        }
    }
}