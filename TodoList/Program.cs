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
        ToDoList toDoManager = new ToDoList();

        bool executando = true;
        System.Console.WriteLine("===Welcome===");
        while (executando)
        {
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. Complete task");
            Console.WriteLine("3. Display all tasks");
            Console.WriteLine("4. Edit task");
            Console.WriteLine("5. Exit");

            var option = toDoManager.ReadInt();

            Menu menu = (Menu)option;
            switch (menu)
            {
                case Menu.Add:
                    Console.WriteLine("Enter task description:");
                    var description = Console.ReadLine();
                    Console.WriteLine("Enter task priority:");
                    var priority = int.Parse(Console.ReadLine());
                    toDoList.AddTask(new Task(description, priority));
                    Console.Clear();
                    break;
                case Menu.Complete:
                    Console.WriteLine("Here is a list of all your tasks:");
                    toDoList.DisplayTasks();
                    Console.WriteLine("Enter task number to complete:");
                    var taskNumber = int.Parse(Console.ReadLine());
                    toDoList.CompleteTask(taskNumber - 1);
                    toDoList.RemoveTask(taskNumber - 1);
                    Console.Clear();
                    break;

                case Menu.DisplayAll:
                    toDoList.DisplayTasks();
                    Console.ReadLine();
                    Console.Clear();
                    break;


                case Menu.Edit:
                    Console.WriteLine("Here is a list of all your tasks:");
                    toDoList.DisplayTasks();
                    Console.WriteLine("Enter task number to edit:");
                    var editTaskNumber = int.Parse(Console.ReadLine());
                    toDoList.EditTask(editTaskNumber - 1);
                    Console.Clear();
                    break;

                case Menu.Exit:
                    executando = false;
                    break;

                default:
                    Console.WriteLine("Invalid input, please try again.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        }
    }
}

