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





            int userSelection;
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                userSelection = GetValidInt("--- Welcome to Number Storage ---\n1. Create - Add an Item\n2. Read - View the Items\n3. Update - Change an Item\n4. Delete - Remove an Item\n5. Sort - Organize the Items\n0. Exit\nPlease make a selection: ");
                if (userSelection == 1)
                {
                    // Create
                    int newItemParsed = GetValidInt("Please enter a number to add: ");
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
                    Console.WriteLine("Press enter to return to menu.");
                    Console.ReadLine();
                }
                else if (userSelection == 3)
                {
                    for (int i = 0; i < numberArrayLogicalSize; i++)
                    {
                        Console.WriteLine($"{i + 1}) {numberArray[i]}");
                    }

                    int modifyIndexParsed = GetValidInt("Please make a selection to modify: ");
                    int newItemParsed = GetValidInt($"Please enter a number to overwrite postion {modifyIndexParsed} ({numberArray[modifyIndexParsed - 1]}) with: ");
                    numberArray[modifyIndexParsed - 1] = newItemParsed;
                }
                else if (userSelection == 4)
                {
                    for (int i = 0; i < numberArrayLogicalSize; i++)
                    {
                        Console.WriteLine($"{i + 1}) {numberArray[i]}");
                    }
                    int deleteIndexParsed = GetValidInt("Please make a selection to modify: ");
                    while (deleteIndexParsed < numberArrayLogicalSize)
                    {
                        // A little counter-intuitive, this is actually the index we are targeting and the next one (since this varialbe is "English" or 1-indexed.
                        SwapArrayIndexes(numberArray, deleteIndexParsed - 1, deleteIndexParsed);
                        deleteIndexParsed++;
                    }
                    // This is a little redundant, as the user will never see it after the logical size shrinks.
                    //numberArray[deleteIndexParsed - 1] = 0;
                    numberArrayLogicalSize--;
                }
                else if (userSelection == 5)
                {
                    Array.Sort(numberArray, null, 0, numberArrayLogicalSize);
                }
            } while (userSelection != 0);
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
        public static void SwapArrayIndexes(int[] array, int indexA, int indexB)
        {
            int temp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = temp;
        }
    }
}
