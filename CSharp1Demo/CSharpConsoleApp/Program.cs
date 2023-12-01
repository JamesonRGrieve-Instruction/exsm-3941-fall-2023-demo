using System;
using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = new string[3];
            string[] passwords = new string[3];
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
                    Console.Write("Please enter your username: ");
                    string username = Console.ReadLine().Trim();
                    Console.Write("Please enter your password: ");
                    string password = Console.ReadLine().Trim();
                    int userIndex = 0;
                    // This prevents additional iterations in the event we uncover a match. It would be a bit more maintainbale as a while loop, but I left it as a for loop to demonstrate that additional conditions can be added.
                    for (int i = 0; i <= logicalSize && !(usernames[i] == username && passwords[i] == password); i++)
                    {
                        userIndex = i+1;
                    }
                    // Since we set userIndex to i+1, the last iteration will set it to 1 above the logical size, meaning in that case, we found no matches.
                    if (userIndex > logicalSize)
                    {
                        Console.WriteLine("Invalid credentials, returning to menu.");
                        Console.ReadLine();
                    }
                    else
                    {
                        string innerUserChoice = "";
                        do
                        {
                            // User/Words Menu
                            Console.Clear();
                            Console.Write($"Welcome, {username}!\n1. View Words\n2. Add Word\n3. Clear Words\n4. Show Account Info\n5. Logout\n\tSelection: ");
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
                }
                else if (outerUserChoice == "2")
                {
                    // Register
                    string username = GetValidUsername(usernames);
                    string password = GetValidPassword();

                    usernames[logicalSize] = username;
                    passwords[logicalSize] = password;
                    timestamps[logicalSize] = DateTime.Now;
                    words[logicalSize] = new List<string>();

                    logicalSize++;
                }
                else if (outerUserChoice != "3")
                {
                    Console.WriteLine("Invalid selection made, press enter to reload the menu.");
                    Console.ReadLine();
                }
            } while (outerUserChoice != "3");


        }
        static string GetValidUsername(string[] existingUsernames)
        {
            string username;
            bool valid = false;
            do
            {
                Console.Write("Please enter your desired username: ");
                username = Console.ReadLine().Trim();
                valid = true;
                if (string.IsNullOrWhiteSpace(username) || existingUsernames.Contains(username))
                {
                    valid = false;
                }
                if (!valid)
                {
                    Console.WriteLine("Your chosen username is invalid, it must not already exist and not be empty.");
                }
            } while (!valid);
            return username;
        }
        static string GetValidPassword()
        {
            string password;
            bool valid = false;
            do
            {
                Console.Write("Please enter your desired password: ");
                password = Console.ReadLine().Trim();
                valid = true;
                if (password.Length < 5)
                {
                    valid = false;
                }
                bool containsDigit = false, containsUpper = false, containsLower = false, containsSymbol = false;
                foreach (char character in password)
                {
                    if (char.IsUpper(character))
                    {
                        containsUpper = true;
                    }
                    if (char.IsLower(character))
                    {
                        containsLower = true;
                    }
                    if (char.IsDigit(character))
                    {
                        containsDigit = true;
                    }
                    if (char.IsSymbol(character))
                    {
                        containsSymbol = true;
                    }
                }
                valid = containsDigit && containsUpper && containsLower && containsSymbol;
                if (!valid)
                {
                    Console.WriteLine("Your chosen password is invalid, it must be at least 5 characters long containing at least one uppercase letter, lowercase letter, digit and symbol.");
                }
            } while (!valid);
            return password;
        }
    }
}
