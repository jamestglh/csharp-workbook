using System;
using System.Linq;
using System.Collections.Generic;

namespace checkpoint3
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            int tasksCreated = 0;
            Console.WriteLine("Welcome to your task list.");
            MainMenu();

            
            void MainMenu()
            {
                System.Console.WriteLine("Please choose an option: ");
                System.Console.WriteLine("1. List tasks");
                System.Console.WriteLine("2. Add a task");
                System.Console.WriteLine("3. Modify a task");
                System.Console.WriteLine("4. Delete a task");
                System.Console.WriteLine("5. Quit");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    TaskLister(); //DONE
                    MainMenu();
                }
                else if (userInput == "2")
                {
                    TaskCreator();   //DONE
                    MainMenu();
                }
                else if (userInput == "3")
                {
                    TaskModifier(); //DONE 
                    MainMenu();
                }
                else if (userInput == "4")
                {
                    TaskDeleter(); //DONE
                    MainMenu();
                }
                else if (userInput == "5")
                {
                    Environment.Exit(0);
                }
                else
                {
                    System.Console.WriteLine("Sorry bud, invalid input.");
                    MainMenu();
                }
            }
            void TaskLister()
            {
                foreach (Task t in tasks)
                {
                    System.Console.WriteLine("Task " + t.id + ": " + t.description + ". Due on " + t.dueDate.ToString("MM/dd/yyyy") + ". Priority is " + t.priority + ".");
                }
            }
            void TaskCreator()
            {
                System.Console.WriteLine("Please enter a description of your task");
                string description = Console.ReadLine();
                System.Console.WriteLine("Please enter a priority for \"" + description + "\". You can just write \"High\", \"Medium\", or \"Low\", or really write whatever you want.");
                string priority = Console.ReadLine();
                DateTime dueDate = new DateTime();
                ParseDateTimeInput();
                void ParseDateTimeInput()
                {
                    System.Console.WriteLine("Please enter a due date. Enter using the format \"Month Day, Year\" (example: January 1, 1979). ");
                    string dueDateInput = Console.ReadLine();
                    try
                    {
                        dueDate = DateTime.Parse(dueDateInput);
                        Console.WriteLine(dueDate.ToString("MM/dd/yyyy"));
                        AddTaskToList();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to parse '{0}', please try again.", dueDateInput);
                        ParseDateTimeInput();
                    }
                }
                void AddTaskToList()
                {
                    tasksCreated++;
                    int id = tasksCreated;
                    System.Console.WriteLine("id for this task is " + id);
                    tasks.Add(new Task(id, false, description, priority, dueDate));
                }
            }
            void TaskDeleter()
            {
                System.Console.WriteLine("Which task do you want to delete?");
                TaskLister();
                string userInput = Console.ReadLine();
                int userInputInt = 0;
                try
                {
                    userInputInt = int.Parse(userInput);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse '{0}', please try again", userInput);
                }
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (userInputInt == tasks[i].id)
                    {
                        tasks.Remove(tasks[i]);
                    }
                }
            }
            void TaskModifier()
            {
                System.Console.WriteLine("Which task do you want to modify? Choose a task number");
                TaskLister();
                string userInput = Console.ReadLine();
                int userInputInt = 0;
                try
                {
                    userInputInt = int.Parse(userInput);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse '{0}', please try again", userInput);
                }
                foreach (Task t in tasks)
                {
                    if (userInputInt == t.id)
                    {
                        System.Console.WriteLine("Do you want to modify 1. the description, 2. the priority, or 3. due date?");
                        string response = Console.ReadLine();
                        if (response == "1")
                        {
                            System.Console.WriteLine("Please enter a new description:");
                            t.description = Console.ReadLine();
                        }
                        else if (response == "2")
                        {
                            System.Console.WriteLine("Please enter a new priority:");
                            t.priority = Console.ReadLine();
                        }
                        else if (response == "3")
                        {
                            ParseDateTimeUpdate();
                        }
                        t.id = userInputInt;
                        System.Console.WriteLine("id for this task is " + t.id);
                    }
                    void ParseDateTimeUpdate()
                    {
                        System.Console.WriteLine("Please enter a new due date. Enter using the format \"Month Day, Year\" (example: January 1, 1979) :");
                        string dueDateInput = Console.ReadLine();
                        try
                        {
                            t.dueDate = DateTime.Parse(dueDateInput);
                            Console.WriteLine("Due date changed to " + t.dueDate.ToString("MM/dd/yyyy"));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Unable to parse '{0}', please try again", dueDateInput);
                            ParseDateTimeUpdate();
                        }
                    }
                }
            }
        }
    }
    public class Task
    {
        public int id { get; set; }
        public bool isComplete = false;
        public string description { get; set; }
        public string priority { get; set; }
        public DateTime dueDate { get; set; }

        public Task(int id, bool isComplete, string description, string priority, DateTime dueDate)
        {
            this.id = id;
            this.isComplete = isComplete;
            this.description = description;
            this.priority = priority;
            this.dueDate = dueDate;
        }
    }
}
