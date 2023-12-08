using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> names = new SortedSet<string>() {
                "John",
                "Jane",
                "Sally",
                "James",
                "Tom"
            };
            Dictionary<string, string> words = new Dictionary<string, string>()
            {
                {"Book", "A physical or digital publication with pages containing text or images, typically used for reading or reference."},
                {"Water", "A clear, colorless, and odorless liquid essential for all forms of life, typically found in rivers, lakes, and oceans."},
                {"House", "A building or structure where people live, usually providing shelter and accommodation."},
                {"Dog", "A domesticated mammal known for its loyalty and companionship to humans, often kept as a pet."},
                {"Cat", "A small domesticated carnivorous mammal known for its agility and independent nature, often kept as a pet."},
                {"Car", "A motor vehicle with four wheels designed for the transportation of people or goods on roads."},
                {"Food", "Any substance consumed by living organisms to provide energy and nutrients for growth and maintenance."},
                {"Sun", "The star at the center of our solar system, which provides light and heat to Earth."},
                {"Time", "The continuous progression of events in the past, present, and future, measured in seconds, minutes, hours, and years."},
                {"Love", "A strong affection, feeling, or emotion of deep care, attachment, or fondness for someone or something."}
            };
            Random rng = new Random();
            // Set up empty queue.
            Queue<string> queuedNames = new Queue<string>();
            Queue<Stack<Dictionary<string, string>>> queuedStacks = new Queue<Stack<Dictionary<string, string>>>();
            // Determine number of people.
            int numberOfPeople = rng.Next(3, 6);
            // Once for each of the number of people...
            for (int p = 0; p < numberOfPeople; p++)
            {
                // Pick a random name.
                string chosen = names.ElementAt(rng.Next(names.Count));
                // Remove it (no dupes).
                names.Remove(chosen);
                // Enqueue it.
                queuedNames.Enqueue(chosen);
                // Determine number of dictionaries.
                int numberOfDictionaries = rng.Next(2, 5);
                Stack<Dictionary<string, string>> personsStack = new Stack<Dictionary<string, string>>();
                for (int d = 0; d < numberOfDictionaries; d++)
                {
                    // Build dictionary.
                    Dictionary<string, string> newDictionary = new Dictionary<string, string>();
                    // Determine number of words.
                    int numberOfWords = rng.Next(1, 4);
                    // Build dictionary. 
                    Dictionary<string, string> temp = new Dictionary<string, string>(words);
                    for (int w = 0; w < numberOfWords; w++)
                    {
                        // Pick a word.
                        int targetIndex = rng.Next(temp.Count);
                        // Add the word.
                        newDictionary.Add(temp.ElementAt(targetIndex).Key, temp.ElementAt(targetIndex).Value);
                        // Remove the word (no dupes).
                        temp.Remove(temp.ElementAt(targetIndex).Key);
                    }
                    // Push dictionary.
                    personsStack.Push(newDictionary);
                }
                queuedStacks.Enqueue(personsStack);
            }

            // Process the queue.
            Console.WriteLine("Press 'enter' to process the queue...");
            Console.ReadLine();

            do
            {
                string name = queuedNames.Dequeue();
                Stack<Dictionary<string, string>> stack = queuedStacks.Dequeue();
                int counter = 1;
                Console.WriteLine($"{name} steps up to the desk with a stack of {stack.Count} dictionaries. ");
                do
                {
                    Console.WriteLine($"{name} places dictionary {counter} on the desk, containing these word(s):");
                    Dictionary<string, string> dictionary = stack.Pop();
                    foreach(KeyValuePair<string, string> word in dictionary)
                    {
                        Console.WriteLine($"\t\"{word.Key}\": {word.Value}");
                    }
                    counter++;
                } while (stack.Count > 0);

            } while (queuedStacks.Count > 0);
        }
    }
}
