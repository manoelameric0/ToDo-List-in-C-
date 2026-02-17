using System;

namespace TodoList.Models;

public class TaskItem
{
    public string Description { get; private set; }
    public bool IsComplete { get; private set; }
    public int Priority { get; private set; }
public DateTime DueDate {get; private set; }

    public TaskItem(string description, int priority, DateTime dueDate)
    {
        if (string.IsNullOrWhiteSpace(description) || description.Length < 6)
            throw new ArgumentException("Description must have at least 6 characters.");

        if (priority < 1 || priority > 3)
            throw new ArgumentException("Priority must be between 1 and 3.");

        if (dueDate < DateTime.Today)
            throw new ArgumentException("Due Date cannot be in the past.");

        Description = description;
        IsComplete = false;
        Priority = priority;
        DueDate = dueDate;
    }
   
    public void CompleteTask()
    {
        IsComplete = true;
    }

    public void Update(string newDescription, int newPriority, DateTime newDueDate)
    {
        Description = newDescription;
        Priority = newPriority;
        DueDate = newDueDate;
    }
}
