using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = new string[3];
            string[] password = new string[3];
            DateTime[] timestamps = new DateTime[3];
            List<string>[] words = new List<string>[3];

            int logicalSize = 0;
            string outerUserChoice = "";

            do
            {
                // Login/Register Menu
                Console.Clear();
                Console.Write("Welcome to The Words Program!\n1. Login\n2. Register\n3. Exit\n\tSelection: ");
                outerUserChoice = Console.ReadLine().Trim();

                if (outerUserChoice == "1")
                {
                    // Login
                    Console.WriteLine("Login.");
                    Console.ReadLine();
                    string innerUserChoice = "";
                    do
                    {
                        // User/Words Menu
                        Console.Clear();
                        Console.Write($"Welcome, {usernames}!\n1. View Words\n2. Add Word\n3. Clear Words\n4. Show Account Info\n5. Logout\n\tSelection: ");
                        innerUserChoice = Console.ReadLine().Trim();
                        if (innerUserChoice == "1")
                        {
                            // View
                            Console.WriteLine("View.");
                            Console.ReadLine();
                        }
                        else if (innerUserChoice == "2")
                        {
                            // Add
                            Console.WriteLine("Add.");
                            Console.ReadLine();
                        }
                        else if (innerUserChoice == "3")
                        {
                            // Clear
                            Console.WriteLine("Clear.");
                            Console.ReadLine();
                        }
                        else if (innerUserChoice == "4")
                        {
                            // Info
                            Console.WriteLine("Info.");
                            Console.ReadLine();
                        }
                        else if (innerUserChoice != "5")
                        {
                            Console.WriteLine("Invalid selection made, press enter to reload the menu.");
                            Console.ReadLine();
                        }
                    } while (innerUserChoice != "5");
                }
                else if (outerUserChoice == "2")
                {
                    // Register
                    Console.WriteLine("Register.");
                    Console.ReadLine();
                }
                else if (outerUserChoice != "3")
                {
                    Console.WriteLine("Invalid selection made, press enter to reload the menu.");
                    Console.ReadLine();
                }
            } while (outerUserChoice!= "3");


        }
    }
}
