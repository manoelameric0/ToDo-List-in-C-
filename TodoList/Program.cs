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
            Console.WriteLine("\n1- Add task");
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
                    toDoManager.CompleteTask();
                    break;

                case Menu.DisplayAll:
                    toDoManager.DisplayTasks();
                    break;


                case Menu.Edit:
                    toDoManager.EditTask();
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

