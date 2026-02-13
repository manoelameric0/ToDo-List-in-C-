using System;

namespace TodoList.Services;



public class ToDoList
{
    private List<Task> tasks;
    private List<Task> tasksComplete;

    public ToDoList()
    {
        tasks = new List<Task>();
        tasksComplete = new List<Task>();
    }

    // Actions
    public void AddTask()
    {
        try
        {
            Console.Write("Enter task description: ");
            string description = ReadString();

            Console.Write("\nEnter task priority:\n\n1- Low\n2- Midle\n3- High\n\nChoose: ");
            int priority = ReadPriority();

            tasks.Add(new Task(description, priority));
            Console.Clear();
        }
        catch (ArgumentException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
            System.Console.WriteLine($"Try Again...\n");
        }
    }

    public void CompleteTask()
    {
        Console.WriteLine("Here is a list of all your tasks:\n");
        var ListOrdened = DisplayTasks();
        Console.Write("\nEnter task number to complete:");
        var taskNumber = ReadNumberTask();

        Task task = ListOrdened[taskNumber - 1];
        tasksComplete.Add(task);

        RemoveTask(task);

        Console.Clear();
        System.Console.WriteLine("\nCongratulations Task Completed!!!\n");

    }

    public void RemoveTask(Task task)
    {
        tasks.Remove(task);
    }

    public void AddComplete(Task task)
    {

    }

    public List<Task> DisplayTasks()
    {
        Console.Clear();
        var sortedTasks = tasks.OrderByDescending(t => t.Priority).ToList();
        var completedTasks = tasksComplete.OrderByDescending(t => t.Priority).ToList();

        if (!sortedTasks.Any())
        {
            Console.WriteLine("\nNo tasks found.\n");
        }
        
        System.Console.WriteLine("===Open Tasks===\n");
        for (int i = 0; i < sortedTasks.Count; i++)
        {

            Priority priority = (Priority)sortedTasks[i].Priority;
            Console.WriteLine($"{i + 1}. {sortedTasks[i].Description} - {(sortedTasks[i].IsComplete ? "Complete" : "Incomplete")} - Priority: {priority}");
        }

        if (completedTasks.Any())
        {
            System.Console.WriteLine("\n\n===Completed Tasks====\n");
            for (int i = 0; i < completedTasks.Count; i++)
            {

                Priority priority = (Priority)completedTasks[i].Priority;
                Console.WriteLine($"{i + 1}. {completedTasks[i].Description} - {(completedTasks[i].IsComplete ? "Complete" : "Incomplete")} - Priority: {priority}");
            }
        }
        
        return sortedTasks;

    }

    public void EditTask()
    {
        Console.WriteLine("Here is a list of all your tasks:\n");
        var ListOrdened = DisplayTasks();
        Console.Write("\nEnter task number to edit: ");
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
