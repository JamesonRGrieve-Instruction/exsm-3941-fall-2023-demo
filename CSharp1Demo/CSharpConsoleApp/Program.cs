using System;
using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime[] dateTimes = new DateTime[5];
            Console.WriteLine(dateTimes[0]);
            Console.WriteLine(dateTimes.Length);
            using (StreamWriter writer = new StreamWriter("test.txt", false))
            {
  
                    // Write each element of the array to the file
                    foreach (var element in dateTimes)
                    {
                        if (element != null && !string.IsNullOrEmpty(element.ToString()))
                        {
                            writer.Write(element);
                            writer.Write(","); // Add a space or any other separator between elements
                        }
                    }

                    writer.WriteLine(); // Move to the next line for the next array
  

            }
            try
            {
                // Use a StreamReader to read from the file
                using (StreamReader reader = new StreamReader("test.txt"))
                {
                    // Read Line 1 which has usernames, split the string and add each name to an array
                    DateTime[] read = reader.ReadLine().Split(',').Select(x => DateTime.Parse(x)).ToArray();
                    DateTime[] parsed = new DateTime[read.Length];                   
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
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
