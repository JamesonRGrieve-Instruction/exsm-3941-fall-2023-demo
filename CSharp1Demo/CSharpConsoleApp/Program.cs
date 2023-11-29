using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // All of these are types of 'collection', essentially they add functionality onto a base 'collection' type that stores values. Thus, they behave slightly differently.
            List<int> intList = new List<int>();
            // HashSets enforce the rule that all items must be unique.
            HashSet<int> intHashSet = new HashSet<int>();
            // SortedSet is a HashSet that also enforces that the items must be in order.
            SortedSet<int> intSortedSet = new SortedSet<int>();
            // Stack is a list with a "queue"-like function similar to a stack of papers on a desk. The most recent addition is the first to be processed (like the thing on top of the stack).
            Stack<int> intStack = new Stack<int>();
            // Queue is another "queue"-like function similar to, well, a queue. The first addition to the queue is the first one processed.
            Queue<int> intQueue = new Queue<int>();

            int[] thingsToAdd = new int[] { 1, 3, 42, 1, 5, 99, 42, 32, 15, 1, 12 };
            foreach (int thing in thingsToAdd)
            {
                intList.Add(thing);
                intHashSet.Add(thing);
                intSortedSet.Add(thing);
                intStack.Push(thing);
                intQueue.Enqueue(thing);
            }


            // You lose some indexing options with some of these collection types, but you can always convert to an array if necessary.
            Console.WriteLine(intSortedSet.ToArray()[2]);

            // We have the ability to simultaneously remove an item from a Stack/Queue and use it for something.
            Console.WriteLine($"Processing stack, item is: {intStack.Pop()}");
            Console.WriteLine($"Processing queue, item is: {intQueue.Dequeue()}");

            // Dictionaries can be indexed by anything, as opposed to everything above that are indexed by integers.
            Dictionary<string, int> intDictionary = new Dictionary<string, int>();

            intDictionary.Add("one", 1);
            intDictionary.Add("two", 2);
            intDictionary.Add("three", 3);
            intDictionary.Add("four", 4);

            Console.WriteLine(intDictionary["three"]);

            // SortedLists are just like dictionaries mixed with SortedSets, whereby they enforce that the keys will always be in order.
            SortedList<string, int> intSortedList = new SortedList<string, int>();

            intSortedList.Add("one", 1);
            intSortedList.Add("two", 2);
            intSortedList.Add("three", 3);
            intSortedList.Add("four", 4);


        }
    }
}
