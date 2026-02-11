using System;

namespace TodoListN;

public class Task
{
    public string Description { get; private set; }
    public bool IsComplete { get; private set; }
    public int Priority { get; private set; }

    public Task(string description, int priority)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Invalid description");
        }

        if (description.Length < 3)
        {
            throw new ArgumentException("description need more charecters");
        }
        Description = description;

        IsComplete = false;

        if (priority <= 0|| priority > 3)
        {
            throw new ArgumentException("Priority Invalid");
        }
        Priority = priority;
    }
   
    public void CompleteTask()
    {
        IsComplete = true;
    }
}
