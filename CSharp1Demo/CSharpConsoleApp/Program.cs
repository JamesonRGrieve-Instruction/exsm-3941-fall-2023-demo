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
                Console.Write("--- Welcome to Number Storage ---\n1. Create - Add an Item\n2. Read - View the Items\n3. Update - Change an Item\n4. Delete - Remove an Item\n5. Sort - Organize the Items\n0. Exit\nPlease make a selection: ");
                userInput = Console.ReadLine().Trim().ToUpper();
                int userSelection;
                while (!int.TryParse(userInput, out userSelection))
                {
                    Console.Write("Invalid input, please try again: ");
                    userInput = Console.ReadLine().Trim().ToUpper();
                }
                if (userSelection == 1)
                {
                    // Create
                    string newItem;
                    Console.Write("Please enter a number to add: ");
                    newItem = Console.ReadLine().Trim().ToUpper();
                    int newItemParsed;
                    while (!int.TryParse(newItem, out newItemParsed))
                    {
                        Console.Write("Invalid input, please try again: ");
                        userInput = Console.ReadLine().Trim().ToUpper();
                    }
                    if (numberArrayLogicalSize < numberArray.Length)
                    {
                        numberArray[numberArrayLogicalSize] = newItemParsed;
                        numberArrayLogicalSize++;
                    }
                    else
                    {
                        Console.WriteLine("Array is full, sorry!");
                    }
                }
                else if (userSelection == 2)
                {
                    for (int i = 0; i < numberArrayLogicalSize; i++)
                    {
                        Console.WriteLine($"{i + 1}) {numberArray[i]}");
                    }
                }
                else if (userSelection == 3)
                {

                }
                else if (userSelection == 4)
                {

                }
                else if (userSelection == 5)
                {

                }
            } while (userInput != "0");
        }
    }
}
