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
            List<DateTime> numberArray = new List<DateTime>();

            DateTime now = DateTime.Now;
            TimeSpan difference = new TimeSpan(8, 0, 0, 0);
            Console.WriteLine($"Exactly one week and one day from today will be {now.Add(difference)}.");

            int userSelection;
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                //Console.Clear();
                userSelection = GetValidInt("--- Welcome to Number Storage ---\n1. Create - Add an Item\n2. Read - View the Items\n3. Update - Change an Item\n4. Delete - Remove an Item\n5. Sort - Organize the Items\n0. Exit\nPlease make a selection: ");
                if (userSelection == 1)
                {
                    // Create
                    DateTime dateTime = DateTime.Now;
                    numberArray.Add(dateTime);
                }
                else if (userSelection == 2)
                {
                    for (int i = 0; i < numberArray.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {numberArray[i]}, {numberArray[i].Ticks} ticks.");
                    }
                    Console.WriteLine("Press enter to return to menu.");
                    Console.ReadLine();
                }
                else if (userSelection == 3)
                {
                    for (int i = 0; i < numberArray.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {numberArray[i]}");
                    }

                    int modifyIndexParsed = GetValidInt("Please make a selection to modify: ");
                    DateTime newItemParsed = DateTime.Now;
                    numberArray[modifyIndexParsed - 1] = newItemParsed;
                }
                else if (userSelection == 4)
                {
                    for (int i = 0; i < numberArray.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {numberArray[i]}");
                    }
                    int deleteIndexParsed = GetValidInt("Please make a selection to delete: ");
                    numberArray.RemoveAt(deleteIndexParsed - 1);
                }
                else if (userSelection == 5)
                {
                    numberArray.Sort();
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
    }
}
