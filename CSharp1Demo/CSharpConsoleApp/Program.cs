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
            List<int> modulusFives = myList.Select((item) => item % 5).ToList();

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

            List<int> orderedByModulusFivesThen = myList.OrderBy(item => item % 5).ThenBy(item => item).ToList();

            // -- Groups --
            List<IGrouping<int, int>> grouped = myList.OrderBy(item => item % 5).GroupBy(item => item % 5).ToList();

            // More Examples
            List<string> filteredCourses = Courses.Where(course => course.Students.Count > 15).Select(course => course.Code).ToList();
            
            // We want all courses returned, just with modified student lists. So we are using a select instead of where (which mutates instead of filters).
            List<Course> studentsContainingE = Courses.Select(course =>
            {
                // The process of the selection involved mutating a property, so we are full-bodying the select method to allow us to be very precise in our operations.
                // In this case we filter the students to where the first name of a given student contains any letter where that letter in lowercase is 'e'.
                course.Students = course.Students.Where(student => student.FirstName.Any(letter => char.ToLower(letter) == 'e')).ToList();
                // The return in this case is the mutated thing (in this case Course) to put into the result of the Select().
                return course;
            }).ToList();


            // 1. Select the last names of the instructor of every course with a odd-numbered course code, in alphabetical order.
            // List<string>

            // 2. Select the count of students in each course who were born in 1998 or 1999.
            // List<int>

            // 3. Select all students with an even birth month, grouped by their course name.
            // List<IGrouping<string, Person>>


        }




        public static List<Course> Courses = new List<Course>()
    {
        new Course
        {
            Code = "C101",
            Name = "Introduction to Programming",
            Description = "Basics of programming in C#",
            Instructor = new Person { FirstName = "Alice", LastName = "Johnson", BirthDate = new DateOnly(1980, 1, 15) },
            Students = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", BirthDate = new DateOnly(1998, 4, 12) },
                new Person { FirstName = "Emily", LastName = "Smith", BirthDate = new DateOnly(1999, 5, 22) },
                new Person { FirstName = "Michael", LastName = "Brown", BirthDate = new DateOnly(1997, 8, 16) },
                new Person { FirstName = "Laura", LastName = "Davis", BirthDate = new DateOnly(1996, 2, 9) },
                new Person { FirstName = "David", LastName = "Miller", BirthDate = new DateOnly(1998, 12, 30) },
                new Person { FirstName = "Sarah", LastName = "Wilson", BirthDate = new DateOnly(2000, 7, 3) },
                new Person { FirstName = "Daniel", LastName = "Moore", BirthDate = new DateOnly(1995, 11, 13) },
                new Person { FirstName = "Anna", LastName = "Taylor", BirthDate = new DateOnly(1999, 3, 28) },
                new Person { FirstName = "James", LastName = "Anderson", BirthDate = new DateOnly(1997, 6, 19) },
                new Person { FirstName = "Sophia", LastName = "Thomas", BirthDate = new DateOnly(2000, 9, 10) },
                new Person { FirstName = "Christopher", LastName = "Jackson", BirthDate = new DateOnly(1998, 1, 23) },
                new Person { FirstName = "Isabella", LastName = "White", BirthDate = new DateOnly(1999, 4, 15) },
                new Person { FirstName = "Benjamin", LastName = "Harris", BirthDate = new DateOnly(1996, 10, 6) },
                new Person { FirstName = "Madison", LastName = "Martin", BirthDate = new DateOnly(1997, 2, 27) },
                new Person { FirstName = "Liam", LastName = "Thompson", BirthDate = new DateOnly(1995, 12, 8) }
            }
        },
        new Course
        {
            Code = "C102",
            Name = "Data Structures",
            Description = "Understanding data structures",
            Instructor = new Person { FirstName = "Bob", LastName = "Smith", BirthDate = new DateOnly(1981, 2, 20) },
            Students = new List<Person>
            {
                new Person { FirstName = "Emily", LastName = "Smith", BirthDate = new DateOnly(2005, 9, 23) },
                new Person { FirstName = "Daniel", LastName = "Johnson", BirthDate = new DateOnly(2001, 7, 15) },
                new Person { FirstName = "Olivia", LastName = "Williams", BirthDate = new DateOnly(1999, 3, 5) },
                new Person { FirstName = "Michael", LastName = "Brown", BirthDate = new DateOnly(2004, 11, 18) },
                new Person { FirstName = "Sophia", LastName = "Jones", BirthDate = new DateOnly(1997, 6, 9) },
                new Person { FirstName = "Matthew", LastName = "Davis", BirthDate = new DateOnly(2000, 2, 14) },
                new Person { FirstName = "Ava", LastName = "Wilson", BirthDate = new DateOnly(2003, 8, 27) },
                new Person { FirstName = "William", LastName = "Miller", BirthDate = new DateOnly(2002, 10, 30) },
                new Person { FirstName = "Emma", LastName = "Taylor", BirthDate = new DateOnly(1998, 12, 7) },
                new Person { FirstName = "James", LastName = "Anderson", BirthDate = new DateOnly(2001, 4, 2) },
                new Person { FirstName = "Lily", LastName = "Martinez", BirthDate = new DateOnly(1999, 1, 25) },
                new Person { FirstName = "Alexander", LastName = "Garcia", BirthDate = new DateOnly(2005, 5, 13) },
                new Person { FirstName = "Grace", LastName = "Thomas", BirthDate = new DateOnly(2000, 10, 8) },
                new Person { FirstName = "Benjamin", LastName = "Hernandez", BirthDate = new DateOnly(2003, 2, 19) },

            }
        },
        new Course
        {
            Code = "C103",
            Name = "Algorithms",
            Description = "Algorithm design and analysis",
            Instructor = new Person { FirstName = "Carol", LastName = "Williams", BirthDate = new DateOnly(1982, 3, 25) },
            Students = new List<Person>
            {
                new Person { FirstName = "Chloe", LastName = "White", BirthDate = new DateOnly(1997, 7, 31) },
                new Person { FirstName = "Ethan", LastName = "Lopez", BirthDate = new DateOnly(2002, 9, 6) },
                new Person { FirstName = "Mia", LastName = "Clark", BirthDate = new DateOnly(1998, 3, 12) },
                new Person { FirstName = "Daniel", LastName = "Lee", BirthDate = new DateOnly(2004, 1, 4) },
                new Person { FirstName = "Charlotte", LastName = "Walker", BirthDate = new DateOnly(2001, 11, 22) },
                new Person { FirstName = "William", LastName = "Perez", BirthDate = new DateOnly(1999, 6, 14) },
                new Person { FirstName = "Olivia", LastName = "Gonzalez", BirthDate = new DateOnly(2000, 7, 28) },
                new Person { FirstName = "Liam", LastName = "Moore", BirthDate = new DateOnly(2003, 12, 9) },
                new Person { FirstName = "Ava", LastName = "King", BirthDate = new DateOnly(2005, 8, 16) },
                new Person { FirstName = "James", LastName = "Scott", BirthDate = new DateOnly(1997, 2, 7) },
                new Person { FirstName = "Sophia", LastName = "Adams", BirthDate = new DateOnly(2002, 4, 20) },
            }
        },
        new Course
        {
            Code = "C104",
            Name = "Database Systems",
            Description = "Fundamentals of database systems",
            Instructor = new Person { FirstName = "David", LastName = "Jones", BirthDate = new DateOnly(1983, 4, 30) },
            Students = new List<Person>
            {
                new Person { FirstName = "Logan", LastName = "Wright", BirthDate = new DateOnly(1998, 9, 3) },
                new Person { FirstName = "Ella", LastName = "Torres", BirthDate = new DateOnly(2001, 3, 15) },
                new Person { FirstName = "Mason", LastName = "Harris", BirthDate = new DateOnly(2004, 6, 28) },
                new Person { FirstName = "Avery", LastName = "Martin", BirthDate = new DateOnly(2000, 5, 11) },
                new Person { FirstName = "Scarlett", LastName = "Brown", BirthDate = new DateOnly(1999, 8, 4) },
                new Person { FirstName = "Jackson", LastName = "Rivera", BirthDate = new DateOnly(2005, 1, 17) },
                new Person { FirstName = "Abigail", LastName = "Smith", BirthDate = new DateOnly(2002, 11, 7) },
                new Person { FirstName = "Henry", LastName = "Anderson", BirthDate = new DateOnly(1997, 4, 20) },
                new Person { FirstName = "Ella", LastName = "Hall", BirthDate = new DateOnly(2001, 6, 2) },
                new Person { FirstName = "Sofia", LastName = "Garcia", BirthDate = new DateOnly(2004, 2, 11) },
                new Person { FirstName = "Liam", LastName = "Williams", BirthDate = new DateOnly(1998, 8, 25) },
                new Person { FirstName = "Lucas", LastName = "Jackson", BirthDate = new DateOnly(2000, 12, 13) },
                new Person { FirstName = "Aria", LastName = "Davis", BirthDate = new DateOnly(2003, 10, 6) },
                new Person { FirstName = "Sophia", LastName = "Clark", BirthDate = new DateOnly(1999, 5, 9) },
                new Person { FirstName = "Carter", LastName = "Hernandez", BirthDate = new DateOnly(2005, 3, 28) },
                new Person { FirstName = "Harper", LastName = "Taylor", BirthDate = new DateOnly(2002, 7, 19) },
                new Person { FirstName = "Mason", LastName = "Moore", BirthDate = new DateOnly(1998, 1, 31) },
                new Person { FirstName = "Evelyn", LastName = "Wright", BirthDate = new DateOnly(2001, 5, 14) },
                new Person { FirstName = "Emma", LastName = "Smith", BirthDate = new DateOnly(2004, 9, 7) },
                new Person { FirstName = "Liam", LastName = "Wilson", BirthDate = new DateOnly(1997, 11, 28) },
                new Person { FirstName = "Olivia", LastName = "Thomas", BirthDate = new DateOnly(2000, 3, 22) },
                new Person { FirstName = "Noah", LastName = "Gonzalez", BirthDate = new DateOnly(2003, 6, 10) }
            }
        },
        new Course
        {
            Code = "C105",
            Name = "Web Development",
            Description = "Web application development",
            Instructor = new Person { FirstName = "Evelyn", LastName = "Brown", BirthDate = new DateOnly(1984, 5, 5) },
            Students = new List<Person>
            {
                new Person { FirstName = "Emily", LastName = "Smith", BirthDate = new DateOnly(2002, 8, 20) },
                new Person { FirstName = "Michael", LastName = "Johnson", BirthDate = new DateOnly(2000, 6, 15) },
                new Person { FirstName = "Sarah", LastName = "Williams", BirthDate = new DateOnly(2001, 5, 4) },
                new Person { FirstName = "David", LastName = "Brown", BirthDate = new DateOnly(1999, 9, 8) },
                new Person { FirstName = "Jessica", LastName = "Davis", BirthDate = new DateOnly(2003, 3, 27) },
                new Person { FirstName = "Matthew", LastName = "Wilson", BirthDate = new DateOnly(2002, 2, 14) },
                new Person { FirstName = "Sophia", LastName = "Miller", BirthDate = new DateOnly(2000, 11, 10) },
                new Person { FirstName = "Andrew", LastName = "Jones", BirthDate = new DateOnly(2001, 7, 9) },
                new Person { FirstName = "Olivia", LastName = "Garcia", BirthDate = new DateOnly(1998, 12, 5) },
                new Person { FirstName = "William", LastName = "Martinez", BirthDate = new DateOnly(2003, 1, 18) },
                new Person { FirstName = "Ava", LastName = "Hernandez", BirthDate = new DateOnly(2002, 10, 25) }
            }
        },
        new Course
        {
            Code = "C106",
            Name = "Software Engineering",
            Description = "Principles of software engineering",
            Instructor = new Person { FirstName = "Frank", LastName = "Davis", BirthDate = new DateOnly(1985, 6, 10) },
            Students = new List<Person>
            {
                new Person { FirstName = "Daniel", LastName = "Lopez", BirthDate = new DateOnly(2000, 9, 2) },
                new Person { FirstName = "Mia", LastName = "Gonzalez", BirthDate = new DateOnly(2001, 6, 30) },
                new Person { FirstName = "James", LastName = "Perez", BirthDate = new DateOnly(1999, 4, 21) },
                new Person { FirstName = "Emma", LastName = "Taylor", BirthDate = new DateOnly(2003, 7, 17) },
                new Person { FirstName = "Benjamin", LastName = "Davis", BirthDate = new DateOnly(2002, 3, 9) },
                new Person { FirstName = "Lily", LastName = "Rodriguez", BirthDate = new DateOnly(2000, 8, 12) },
                new Person { FirstName = "Liam", LastName = "Harris", BirthDate = new DateOnly(1998, 5, 23) },
                new Person { FirstName = "Chloe", LastName = "Clark", BirthDate = new DateOnly(2001, 12, 28) },
                new Person { FirstName = "Ethan", LastName = "Walker", BirthDate = new DateOnly(2003, 2, 3) },
                new Person { FirstName = "Isabella", LastName = "Young", BirthDate = new DateOnly(2000, 10, 7) },
                new Person { FirstName = "Michael", LastName = "Scott", BirthDate = new DateOnly(2002, 11, 19) },
                new Person { FirstName = "Avery", LastName = "Lee", BirthDate = new DateOnly(1999, 3, 14) },
                new Person { FirstName = "Samantha", LastName = "Lewis", BirthDate = new DateOnly(2003, 9, 28) },
                new Person { FirstName = "Nicholas", LastName = "Hall", BirthDate = new DateOnly(2001, 8, 6) },
                new Person { FirstName = "Madison", LastName = "Baker", BirthDate = new DateOnly(2000, 4, 1) }
            }
        },
        new Course
        {
            Code = "C107",
            Name = "Operating Systems",
            Description = "Concepts in operating systems",
            Instructor = new Person { FirstName = "Grace", LastName = "Miller", BirthDate = new DateOnly(1986, 7, 15) },
            Students = new List<Person>
            {
                new Person { FirstName = "Alexander", LastName = "Green", BirthDate = new DateOnly(1998, 1, 31) },
                new Person { FirstName = "Ava", LastName = "Murphy", BirthDate = new DateOnly(2003, 5, 11) },
                new Person { FirstName = "Elijah", LastName = "Turner", BirthDate = new DateOnly(2002, 6, 7) },
                new Person { FirstName = "Grace", LastName = "White", BirthDate = new DateOnly(2000, 7, 26) },
                new Person { FirstName = "William", LastName = "King", BirthDate = new DateOnly(1999, 2, 22) },
                new Person { FirstName = "Lily", LastName = "Evans", BirthDate = new DateOnly(2003, 8, 15) },
                new Person { FirstName = "Logan", LastName = "Wright", BirthDate = new DateOnly(2001, 9, 9) },
                new Person { FirstName = "Ella", LastName = "Adams", BirthDate = new DateOnly(2000, 3, 2) },
                new Person { FirstName = "Ryan", LastName = "Clarkson", BirthDate = new DateOnly(1998, 11, 6) },
                new Person { FirstName = "Sophia", LastName = "Parker", BirthDate = new DateOnly(2002, 12, 10) },
                new Person { FirstName = "Noah", LastName = "Morgan", BirthDate = new DateOnly(2001, 10, 13) },
                new Person { FirstName = "Aria", LastName = "Mitchell", BirthDate = new DateOnly(2003, 6, 29) },
                new Person { FirstName = "Jackson", LastName = "Russell", BirthDate = new DateOnly(2000, 4, 8) },
                new Person { FirstName = "Mia", LastName = "Bennett", BirthDate = new DateOnly(1999, 1, 17) },
                new Person { FirstName = "Lucas", LastName = "Reed", BirthDate = new DateOnly(2003, 4, 7) },
                new Person { FirstName = "Charlotte", LastName = "Bailey", BirthDate = new DateOnly(2002, 3, 20) },
                new Person { FirstName = "Aiden", LastName = "Foster", BirthDate = new DateOnly(2000, 9, 26) },
                new Person { FirstName = "Olivia", LastName = "Sullivan", BirthDate = new DateOnly(1998, 7, 14) },
                new Person { FirstName = "Ethan", LastName = "Powell", BirthDate = new DateOnly(2001, 2, 11) },
            }
        }
    };
    }
}
