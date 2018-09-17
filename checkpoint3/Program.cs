using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace checkpoint3
{
    class Program
    {
        public static void Main(string[] args)
        {
            TaskContext taskContext = new TaskContext();
            taskContext.Database.EnsureCreated();
            Console.WriteLine("Welcome to your task list.");
            MainMenu();

            void MainMenu()
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Please choose an option: ");
                System.Console.WriteLine("1. List ALL tasks");
                System.Console.WriteLine("2. List UNFINISHED tasks");
                System.Console.WriteLine("3. List FINISHED tasks");
                System.Console.WriteLine("4. Add a task");
                System.Console.WriteLine("5. Modify a task");
                System.Console.WriteLine("6. Mark task as finished / unfinished");
                System.Console.WriteLine("7. Delete a task");
                System.Console.WriteLine("8. Quit");
                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.Clear();
                    TaskLister();
                    MainMenu();
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    TaskListerUnfinished();
                    MainMenu();
                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    TaskListerFinished();
                    MainMenu();
                }
                else if (userInput == "4")
                {
                    Console.Clear();
                    TaskCreator();
                    MainMenu();
                }
                else if (userInput == "5")
                {
                    Console.Clear();
                    TaskModifier_db();
                    MainMenu();
                }
                else if (userInput == "6")
                {
                    Console.Clear();
                    TaskStatusUpdater();
                    MainMenu();
                }
                else if (userInput == "7")
                {
                    Console.Clear();
                    TaskDeleter();
                    MainMenu();
                }
                else if (userInput == "8")
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
                string status = "";
                foreach (Task t in taskContext.tasks_db)
                {
                    if (t.isComplete)
                    {
                        status = "complete";
                    }
                    else
                    {
                        status = "incomplete";
                    }
                    System.Console.WriteLine("Task " + t.id + ": " + t.description + " is " + status + ". Due on " + t.dueDate.ToString("MM/dd/yyyy") + ". Priority is " + t.priority + ".");
                }
            }
            void TaskListerUnfinished()
            {
                foreach (Task t in taskContext.tasks_db)
                {
                    if (!t.isComplete)
                    {
                        System.Console.WriteLine("Task " + t.id + ": " + t.description + " is unfinshed. Due on " + t.dueDate.ToString("MM/dd/yyyy") + ". Priority is " + t.priority + ".");
                    }
                }
            }
            void TaskListerFinished()
            {
                foreach (Task t in taskContext.tasks_db)
                {
                    if (t.isComplete)
                    {
                        System.Console.WriteLine("Task " + t.id + ": " + t.description + " is complete. Due on " + t.dueDate.ToString("MM/dd/yyyy") + ". Priority is " + t.priority + ".");
                    }
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
                    System.Console.WriteLine("Please enter a due date. Enter using the format \"Month Day, Year\" or \"MM/DD/YYYY\" (example: January 1, 1979). ");
                    string dueDateInput = Console.ReadLine();
                    try
                    {
                        dueDate = DateTime.Parse(dueDateInput);
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
                    int id = taskContext.tasks_db.Max(t => t.id) + 1;
                    taskContext.tasks_db.Add(new Task(id, false, description, priority, dueDate));
                    taskContext.SaveChanges();
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
                foreach (Task t in taskContext.tasks_db)
                {
                    if (userInputInt == t.id)
                    {
                        taskContext.tasks_db.Remove(t);
                        taskContext.SaveChanges();
                    }
                }
            }
            void TaskModifier_db()
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
                foreach (Task t in taskContext.tasks_db)
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
                    taskContext.SaveChanges();
                }
            }
            void TaskStatusUpdater()
            {
                System.Console.WriteLine("Which task do you want to update the status on? Choose a task number");
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
                foreach (Task t in taskContext.tasks_db)
                {
                    if (userInputInt == t.id)
                    {
                        if (t.isComplete)
                        {
                            System.Console.WriteLine("Do you want to mark this task as INCOMPLETE? y/n");
                            userInput = Console.ReadLine();
                            if (userInput.ToLower() == "y")
                            {
                                t.isComplete = false;
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Do you want to mark this task as COMPLETE? y/n");
                            userInput = Console.ReadLine();
                            if (userInput.ToLower() == "y")
                            {
                                t.isComplete = true;
                            }
                        }
                    }
                }
                System.Console.WriteLine("Task updated!");
                taskContext.SaveChanges();
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
        public Task() { }
    }
    public class TaskContext : DbContext
    {
        public DbSet<Task> tasks_db { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./tasks.db");
        }
    }
}
