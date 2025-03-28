using System;
using System.IO;

namespace ToDoListApp
{
    class Program
    {
        // Method to add a task
        static void AddTask(string task)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("tasks.txt", true))
                {
                    sw.WriteLine(task);
                    Console.WriteLine("Task added successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Method to view tasks
        static void ViewTasks()
        {
            try
            {
                if (File.Exists("tasks.txt"))
                {
                    string[] tasks = File.ReadAllLines("tasks.txt");
                    if (tasks.Length == 0)
                    {
                        Console.WriteLine("No tasks found.");
                    }
                    else
                    {
                        Console.WriteLine("Saved Tasks:");
                        foreach (string task in tasks)
                        {
                            Console.WriteLine("- " + task);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No tasks file found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Main method where user interacts with the program
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nTo-Do List Application");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter a task: ");
                        string task = Console.ReadLine();
                        AddTask(task);
                        break;
                    case "2":
                        ViewTasks();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
