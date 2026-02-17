using System;
using TodoList.Models;
using TodoList.Services.Interface;

namespace TodoList.Services;



public class TaskService: ITaskService
{
    private List<TaskItem> _tasks = new List<TaskItem>();

    // Actions
    public void Add(string description, int priority, DateTime dueDate)
    {
        if (_tasks.Any(t => t.Description.Equals(description, StringComparison.OrdinalIgnoreCase)))
        throw new ArgumentException("Description already exists.");

        _tasks.Add(new TaskItem(description, priority, dueDate));
    }

    public void Complete(int index)
    {
        var tasks = GetAll();

        var task = tasks[index -1];
        task.CompleteTask();
    }

    public void Remove(int index)
    {
        var tasks = GetAll();

        var task = tasks[index -1];
        _tasks.Remove(task);
    }


    public List<TaskItem> GetAll()
    {
        
        return _tasks.OrderByDescending(t=> t.Priority).ToList();
    }

    public void Edit(int index, string newDescription, int newPriority, DateTime newDueDate)
    {
        if (_tasks.Any(t => t.Description.Equals(newDescription, StringComparison.OrdinalIgnoreCase)))
        throw new ArgumentException("Description already exists.");

        var tasks = GetAll();

        var task = tasks[index -1];
        task.Update(newDescription:newDescription, newPriority:newPriority, newDueDate:newDueDate);
    }

    


}
