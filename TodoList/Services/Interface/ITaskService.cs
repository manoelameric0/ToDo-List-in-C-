using System;
using System.ComponentModel;
using TodoList.Models;

namespace TodoList.Services.Interface;

public interface ITaskService
{
    void Add (string description, int priority);
    void Complete(int index);
    void Remove(int index);
    void Edit(int index, string newDescription, int newPriority);
    List<TaskItem> GetAll();
}
