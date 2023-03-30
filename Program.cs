using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicAuthentication
{
    class Program
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n== BASIC AUTHENTICATION ==");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show Users");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Login");
                Console.WriteLine("5. Exit");
                Console.Write("\nInput: ");

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateUser();
                            break;
                        case 2:
                            ShowUsers();
                            break;
                        case 3:
                            SearchUser();
                            break;
                        case 4:
                            Login();
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        static void CreateUser()
        {
            Console.Write("First Name: ");
            string firstname = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastname = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (!users.ContainsKey(firstname))
            {
                users.Add(firstname, password);
                Console.WriteLine("\nUser created successfully.");
            }
            else
            {
                Console.WriteLine("\nUser already exists. Please choose a different username.");
            }
        }

        static void ShowUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\nNo users found.");
            }
            else
            {
                Console.WriteLine("== SHOW USER ==");
                Console.WriteLine("ID :");
                Console.WriteLine("Name :");
                Console.WriteLine("username : ");
                Console.WriteLine("password :");
                foreach (var user in users)
                {
                    Console.WriteLine(user.Key);
                }
            }
        }

        static void SearchUser()
        {
            Console.Write("\nEnter a username to search: ");
            string username = Console.ReadLine();

            if (users.ContainsKey(username))
            {
                Console.WriteLine($"\nUser found. Username: {username}, Password: {users[username]}");
            }
            else
            {
                Console.WriteLine("\nUser not found.");
            }
        }

        static void Login()
        {
            Console.Write("\nEnter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (users.ContainsKey(username) && users[username] == password)
            {
                Console.WriteLine("\nLogin successful.");
            }
            else
            {
                Console.WriteLine("\nLogin failed. Invalid username or password.");
            }
        }
    }
}
