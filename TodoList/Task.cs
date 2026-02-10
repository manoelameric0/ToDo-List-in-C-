using System;

namespace TodoListN;

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
