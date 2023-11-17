using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int playAgain = 0;
            Random rng = new Random();
            Console.WriteLine("--- Higher / Lower Guessing Game ---\nEnter a maximum value to play to.");
            int maximum = GetRangedInput(1, 1000);
            do
            {
                if (playAgain == 2)
                {
                    Console.WriteLine("Enter a maximum value to play to.");
                    maximum = GetRangedInput(1, 1000);
                }
                int target = rng.Next(1, maximum + 1);
                int guess;
                int guessCount = 0;
                do
                {
                    Console.WriteLine($"Guess {guessCount+1}");
                    guess = GetRangedInput(1, maximum);
                    guessCount++;
                    if (guess < target)
                    {
                        Console.WriteLine("Higher!");
                    }
                    else if (guess > target)
                    {
                        Console.WriteLine("Lower!");
                    }
                } while (guess != target);
                Console.WriteLine($"You took {guessCount} guess(es), the answer was {target}.\n1. Play Again (Same Range)\n2. Play Again (New Range)\n3. Exit");
                playAgain = GetRangedInput(1, 3);
            } while (playAgain != 3);
        }


        public static int GetRangedInput(int min, int max)
        /*
        Prompts the user for an integer between min and max inclusive until they make a valid input. 
        If min is less than 1, or max is greater than 1000, throw an ArgumentOutOfRangeException.
        */
        {
            int toReturn;
            if (min < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(min));
            }
            if (max > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(max));
            }
            Console.Write($"Please enter a whole number between {min} and {max}, inclusive: ");
            while (!int.TryParse(Console.ReadLine(), out toReturn) || !ValidateRangedInput(min, max, toReturn))
            {
                Console.Write($"Error, please try again. Please enter a whole number between {min} and {max}, inclusive.");
            }
            return toReturn;
        }
        public static bool ValidateRangedInput(int min, int max, int value)
        /*
        If value is greater than max, or less than min, return false.
        Otherwise return true.
        */
        {
            return min <= value && value <= max;
        }
    }
}
