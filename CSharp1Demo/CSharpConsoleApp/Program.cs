using System;
using System.Runtime.Serialization.Formatters;

namespace CSharpConsoleApp
{
    public struct User
    {
        public string username;
        public string password;
        public DateTime timestamp;
        public List<string> words;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[3];
            string line = "";
            int logicalSize = 0;
            const string FILE_NAME = "users.csv";
            // username,password,timestamp,word1,word2,word3...
            try
            {
                using (StreamReader sr = new StreamReader(FILE_NAME))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        users[logicalSize] = new User()
                        {
                            username = values[0],
                            password = values[1],
                            timestamp = DateTime.Parse(values[2]),
                            words = new List<string>()
                        };
                        for (int i = 3; i < values.Length; i++)
                        {
                            users[logicalSize].words.Add(values[i]);
                        }
                        logicalSize++;
                    }
                }
            }
            catch (Exception e) { }
            
            
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
                    for (int i = 0; i <= logicalSize && !(users[i].username == username && users[i].password == password); i++)
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
                                foreach(string word in users[userIndex].words)
                                {
                                    Console.WriteLine(word);
                                }
                                Console.ReadLine();
                            }
                            else if (innerUserChoice == "2")
                            {
                                // Add
                                Console.Write("Please enter the word to add: ");
                                string word = Console.ReadLine().Trim();
                                if (word.Length > 0 && !word.Contains(' '))
                                {
                                    users[userIndex].words.Add(word);
                                    SaveData(users, logicalSize, FILE_NAME);
                                }
                                else
                                {
                                    Console.WriteLine("No word or multiple words entered, returning to menu.");
                                }
                                Console.ReadLine();
                            }
                            else if (innerUserChoice == "3")
                            {
                                // Clear
                                users[userIndex].words.Clear();
                                SaveData(users, logicalSize, FILE_NAME);
                                Console.ReadLine();
                            }
                            else if (innerUserChoice == "4")
                            {
                                // Info
                                Console.WriteLine($"User {users[userIndex].username} created at {users[userIndex].timestamp.ToLongTimeString()} on {users[userIndex].timestamp.ToLongDateString()}. This was {DateTime.Now-users[userIndex].timestamp} ago.");
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
                    if (logicalSize < 3)
                    {
                        string username = GetValidUsername(users);
                        string password = GetValidPassword(username);

                        users[logicalSize].username = username;
                        users[logicalSize].password = password;
                        users[logicalSize].timestamp = DateTime.Now;
                        users[logicalSize].words = new List<string>();

                        logicalSize++;
                        SaveData(users, logicalSize, FILE_NAME);
                    }
                    else
                    {
                        Console.WriteLine("Maximum users stored, returning to menu.");
                        Console.ReadLine();
                    }
                }
                else if (outerUserChoice != "3")
                {
                    Console.WriteLine("Invalid selection made, press enter to reload the menu.");
                    Console.ReadLine();
                }
            } while (outerUserChoice != "3");


        }
        static string GetValidUsername(User[] existingUsers)
        {
            string username;
            bool valid = false;
            do
            {
                Console.Write("Please enter your desired username: ");
                username = Console.ReadLine().Trim();
                valid = true;
                foreach (User user in existingUsers)
                {
                    if (user.username == username)
                    {
                        valid = false;
                    }
                }
                if (string.IsNullOrWhiteSpace(username))
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
        static string GetValidPassword(string pairedUsername)
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
                if (pairedUsername == password)
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
                valid = valid && containsDigit && containsUpper && containsLower && containsSymbol;
                if (!valid)
                {
                    Console.WriteLine("Your chosen password is invalid, it must be at least 5 characters long containing at least one uppercase letter, lowercase letter, digit and symbol. It cannot be the same as the username.");
                }
            } while (!valid);
            return password;
        }

        static void SaveData(User[] data, int logicalSize, string fileName)
        {
            int written = 0;
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                do
                {
                    sw.WriteLine($"{data[written].username},{data[written].password},{data[written].timestamp}{(data[written].words.Count>0?",":"")}{string.Join(',', data[written].words)}");
                    written++;
                } while (written < logicalSize);
            }
        }
    }
}
