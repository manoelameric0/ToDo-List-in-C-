using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TodoListN;

namespace ToDoListN;



class Program
{
    static void Main(string[] args)
    {
        ToDoList toDoManager = new ToDoList();

        bool executando = true;
        System.Console.WriteLine("===Welcome===");
        while (executando)
        {
            Console.WriteLine("1- Add task");
            Console.WriteLine("2- Complete task");
            Console.WriteLine("3- Display all tasks");
            Console.WriteLine("4- Edit task");
            Console.WriteLine("5- Exit");
            Console.Write("Choose: ");

            var option = toDoManager.ReadMenu();

            Menu menu = (Menu)option;
            switch (menu)
            {
                case Menu.Add:
                    toDoManager.AddTask();

                    break;
                case Menu.Complete:

                    break;

                case Menu.DisplayAll:
                    //toDoList.DisplayTasks();
                    Console.ReadLine();
                    Console.Clear();
                    break;


                case Menu.Edit:
                    Console.WriteLine("Here is a list of all your tasks:");
                    //toDoList.DisplayTasks();
                    Console.WriteLine("Enter task number to edit:");
                    var editTaskNumber = int.Parse(Console.ReadLine());
                    //toDoList.EditTask(editTaskNumber - 1);
                    Console.Clear();
                    break;

                case Menu.Exit:
                    executando = false;
                    break;

                default:
                    Console.WriteLine("Invalid Type 1 at 5\n");

                    break;
            }
        }
    }
}

