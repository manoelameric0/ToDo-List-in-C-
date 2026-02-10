using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TodoListN;

namespace ToDoListN;



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

