using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpConsoleApp
{
    public struct Person
    {
        public string FirstName;
        public string LastName;
        public DateOnly BirthDate;
    }
    public struct Course
    {
        public string Code;
        public string Name;
        public string Description;
        public Person Instructor;
        public List<Person> Students;
    }

    
}
