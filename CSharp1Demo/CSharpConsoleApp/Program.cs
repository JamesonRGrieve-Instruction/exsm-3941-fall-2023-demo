using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>() { 1, 5, 7, 12, 42, 3, 9, 32, 75, 99, 110, 47, 83, 63 };

            // Where allows filtering of collections similar to .filter() in JavaScript.
            List<int> myListFiltered = myList.Where((item) => item > 50).ToList();

            List<int> filtered = new List<int>();
            foreach (int item in myList)
            {
                if (item > 50)
                {
                    filtered.Add(item);
                }
            }

            // Select allows you to generate or select new values based on the current values similar to .map() in JavaScript.
            List<int> modulusFives = myList.Select((item) => item%5).ToList();

            // -- Aggregates --

            // Count uses a Where-Like function.
            int evenCount = myList.Where((item) => item % 2 == 0).Count();
            int anotherEvenCount = myList.Count((item) => item % 2 == 0);

            // Sum, average, min and max use a Select-Like function.
            int evenSum = myList.Sum((item) => item % 5);
            int evenMin = myList.Min((item) => item % 5);
            int evenMax = myList.Max((item) => item % 5);
            double evenAverage = myList.Average((item) => item % 5);
            // Providing no argument runs the function on the items as-is.
            double average = myList.Average();

            // -- Ordering --
            // Note that while we use a selection function in OrderBy, the result maintains the original items. This would not be the case if we did .Select().OrderBy().
            List<int> orderedByModulusFives = myList.OrderBy(item => item % 5).ToList();
            List<int> orderedByModulusFivesReversed = myList.OrderByDescending(item => item % 5).ToList();

            List<int> orderedByModulusFivesThen = myList.OrderBy(item => item % 5).ThenBy(item=>item).ToList();

            // -- Groups --
            List<IGrouping<int, int>> grouped = myList.OrderBy(item => item % 5).GroupBy(item => item % 5).ToList();

        }

    }
}
