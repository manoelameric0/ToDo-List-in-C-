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
                Console.Write("Enter task description:");
                var description = Console.ReadLine();
                Console.Write("Enter task priority:");
                int.TryParse(Console.ReadLine(), out int priority);
                tasks.Add(new Task(description, priority));
                Console.Clear();
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
                System.Console.WriteLine($"Try Again...");
            }
        }
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

    // Validation

    public int ReadInt()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Invalid Type 1 at 5");
        }

        return input;
    }

    public string ReadString()
    {
        string entrada = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(entrada) || int.TryParse(entrada, out int a))
        {
            throw new ArgumentException("Invalid Description");
        }

        return entrada;

    }


}
