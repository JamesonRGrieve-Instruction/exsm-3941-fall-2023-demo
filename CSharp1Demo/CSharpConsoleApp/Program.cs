using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public struct PersonWithDictionaries
    {
        public string Name;
        public Stack<Dictionary<string, string>> Dictionaries;
    }
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
            Queue<PersonWithDictionaries> personQueue = new Queue<PersonWithDictionaries>();
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
                PersonWithDictionaries newPerson = new PersonWithDictionaries()
                {
                    Name = chosen,
                    Dictionaries = new Stack<Dictionary<string, string>>()
                };
                // Determine number of dictionaries.
                int numberOfDictionaries = rng.Next(2, 5);
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
                    newPerson.Dictionaries.Push(newDictionary);
                }
                personQueue.Enqueue(newPerson);
            }

            // Process the queue.
            Console.WriteLine("Press 'enter' to process the queue...");
            Console.ReadLine();

            do
            {
                PersonWithDictionaries person = personQueue.Dequeue();
                int counter = 1;
                Console.WriteLine($"{person.Name} steps up to the desk with a stack of {person.Dictionaries.Count} dictionaries. ");
                do
                {
                    Console.WriteLine($"{person.Name} places dictionary {counter} on the desk, containing these word(s):");
                    Dictionary<string, string> dictionary = person.Dictionaries.Pop();
                    foreach (KeyValuePair<string, string> word in dictionary)
                    {
                        Console.WriteLine($"\t\"{word.Key}\": {word.Value}");
                    }
                    counter++;
                } while (person.Dictionaries.Count > 0);

            } while (personQueue.Count > 0);
        }
    }
}
