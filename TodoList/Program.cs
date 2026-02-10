using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoList
{
    public class Task
    {
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int Priority { get; set; }

        public Task(string description, int priority)
        {
            Description = description;
            IsComplete = false;
            Priority = priority;
        }

        public void CompleteTask()
        {
            IsComplete = true;
        }
    }

    public class ToDoList
    {
        private List<Task> tasks;

        public ToDoList()
        {
            tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void CompleteTask(int taskNumber)
        {
            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                tasks[taskNumber].CompleteTask();
            }
        }

        public void RemoveTask(int taskNumber)
        {
            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                tasks.RemoveAt(taskNumber);
            }
        }

        public void DisplayTasks()
        {
            var sortedTasks = tasks.OrderBy(t => t.Priority).ToList();
            for (int i = 0; i < sortedTasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedTasks[i].Description} - {(sortedTasks[i].IsComplete ? "Complete" : "Incomplete")} - Priority: {sortedTasks[i].Priority}");
            }
        }

        public void EditTask(int taskNumber)
        {
            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                Console.WriteLine("Enter new task description:");
                var newDescription = Console.ReadLine();
                Console.WriteLine("Enter new task priority:");
                var newPriority = int.Parse(Console.ReadLine());
                tasks[taskNumber].Description = newDescription;
                tasks[taskNumber].Priority = newPriority;
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ToDoList toDoList = new ToDoList();

            while (true)
            {
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Complete task");
                Console.WriteLine("3. Display all tasks");
                Console.WriteLine("4. Edit task");
                Console.WriteLine("5. Exit");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter task description:");
                        var description = Console.ReadLine();
                        Console.WriteLine("Enter task priority:");
                        var priority = int.Parse(Console.ReadLine());
                        toDoList.AddTask(new Task(description, priority));
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Here is a list of all your tasks:");
                        toDoList.DisplayTasks();
                        Console.WriteLine("Enter task number to complete:");
                        var taskNumber = int.Parse(Console.ReadLine());
                        toDoList.CompleteTask(taskNumber - 1);
                        toDoList.RemoveTask(taskNumber - 1);
                        Console.Clear();
                        break;

                    case "3":
                        toDoList.DisplayTasks();
                        Console.ReadLine();
                        Console.Clear();
                        break;


                    case "4":
                        Console.WriteLine("Here is a list of all your tasks:");
                        toDoList.DisplayTasks();
                        Console.WriteLine("Enter task number to edit:");
                        var editTaskNumber = int.Parse(Console.ReadLine());
                        toDoList.EditTask(editTaskNumber - 1);
                        Console.Clear();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
