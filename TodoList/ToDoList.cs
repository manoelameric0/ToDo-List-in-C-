using System;

namespace TodoListN;

// Menu
public enum Menu { Add = 1, Complete = 2, DisplayAll = 3, Edit = 4, Exit = 5 }

public class ToDoList
{
    private List<Task> tasks;

    public ToDoList()
    {
        tasks = new List<Task>();
    }

    // Actions
    public void AddTask()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter task description: ");
                string description = ReadString();

                Console.Write("\nEnter task priority:\n\n1- Low\n2- Midle\n3- High\n\nChoose: ");
                int priority = ReadPriority();

                tasks.Add(new Task(description, priority));
                Console.Clear();
                break;
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
                System.Console.WriteLine($"Try Again...\n");
            }
        }
    }

    public void CompleteTask()
    {
        Console.WriteLine("Here is a list of all your tasks:");
        DisplayTasks();
        Console.WriteLine("Enter task number to complete:");
        var taskNumber = int.Parse(Console.ReadLine());
        //CompleteTask(taskNumber - 1);
        RemoveTask(taskNumber - 1);
        Console.Clear();
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

    public List<Task> DisplayTasks()
    {
        var sortedTasks = tasks.OrderByDescending(t => t.Priority).ToList();
        for (int i = 0; i < sortedTasks.Count; i++)
        {

            Priority priority = (Priority)sortedTasks[i].Priority;
            Console.WriteLine($"\n{i + 1}. {sortedTasks[i].Description} - {(sortedTasks[i].IsComplete ? "Complete" : "Incomplete")} - Priority: {priority}\n");
        }
        Console.Clear();
        return sortedTasks;

    }

    public void EditTask()
    {
        Console.WriteLine("Here is a list of all your tasks:");
        var ListOrdened = DisplayTasks();
        Console.Write("Enter task number to edit: ");
        int taskNumber = ReadNumberTask();

        Task task = ListOrdened[taskNumber - 1];

        Console.Write("\nEnter new task description:");
        var newDescription = ReadString();
        Console.WriteLine("\nEnter task priority:\n\n1- Low\n2- Midle\n3- High\n\nChoose: ");
        var newPriority = ReadPriority();
        task.newDescription(newDescription);
        task.newPriority(newPriority);
        Console.Clear();

    }

    // Validation

    public string ReadString()
    {
        string entrada = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(entrada) || int.TryParse(entrada, out int a) || entrada.Length < 6)
        {
            System.Console.WriteLine("\nInvalid Description Minimum 6 Character\n");
            Console.Write("Enter task description:");
            entrada = Console.ReadLine();
        }

        return entrada;

    }

    public int ReadPriority()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input) || input > 3 || input <= 0)
        {
            System.Console.WriteLine("\nInvalid Charactere\n");
            System.Console.Write("Choose: ");
        }
        return input;
    }

    public int ReadMenu()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            System.Console.WriteLine("\nInvalid. Choose type 1 at 5\n");
            System.Console.Write("Choose: ");
        }
        return input;
    }

    public int ReadNumberTask()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input) || input <= 0 || input > tasks.Count)
        {
            Console.WriteLine("Invalid Number Task! Try again...");
            Console.Write("Enter task number to edit: ");

        }
        return input;
    }


}
