using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toDoList
{
    // Task class to represent a task
    public class Task
    {
        public int Id;
        public string Name;
        public DateTime DueDate;
        public string Priority;

        public override string ToString()
        {
            return " ID : " + Id + "," + " Name : " + Name + "," + " Due Date : " + DueDate.ToShortDateString() + "," + " Priority : " + Priority;
        }


        // List to store tasks
        public static List<Task> tasks = new List<Task>();
        public static int nextId = 1;


        public static void AddTask()
        {
            Task newTask = new Task();
            newTask.Id = nextId++;
            Console.Write("Enter task name: ");
            newTask.Name = Console.ReadLine();
            Console.Write("Enter due date (yyyy-mm-dd): ");
            newTask.DueDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter priority (High, Medium, Low): ");
            newTask.Priority = Console.ReadLine();
            tasks.Add(newTask);
            Console.WriteLine("Task added successfully.");
        }
        public static void EditTask()
        {
            Console.Write("Enter task ID to edit: ");
            int id = int.Parse(Console.ReadLine());
            Task task = tasks.Find(t => t.Id == id);

            if (task != null)
            {
                Console.Write("Enter new task name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    task.Name = name;
                }

                Console.Write("Enter new due date (yyyy-mm-dd, leave blank to keep current): ");
                string dueDateInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(dueDateInput))
                {
                    task.DueDate = DateTime.Parse(dueDateInput);
                }

                Console.Write("Enter new priority (leave blank to keep current): ");
                string priority = Console.ReadLine();
                if (!string.IsNullOrEmpty(priority))
                {
                    task.Priority = priority;
                }

                Console.WriteLine("Task updated successfully.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        public static void DeleteTask()
        {
            Console.Write("Enter task ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Task task = tasks.Find(t => t.Id == id);

            if (task != null)
            {
                tasks.Remove(task);
                Console.WriteLine("Task deleted successfully.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        public static void SearchTaskById()
        {
            Console.Write("Enter task ID to search: ");
            int id = int.Parse(Console.ReadLine());
            Task task = tasks.Find(t => t.Id == id);

            if (task != null)
            {
                Console.WriteLine("Task found: " + task);
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        public static void DisplayAllTasks()
        {
            Console.WriteLine("\nAll Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("============================================================");
                Console.WriteLine("\nTo-Do List Menu:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Edit Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Search Task by ID");
                Console.WriteLine("5. Display All Tasks");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        EditTask();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        SearchTaskById();
                        break;
                    case "5":
                        DisplayAllTasks();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
