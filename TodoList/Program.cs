using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TodoList.Enums;
using TodoList.Models;
using TodoList.Services;
using TodoList.Services.Interface;

namespace TodoList;



class Program
{
    static void Main(string[] args)
    {
        ITaskService taskService = new TaskService();

        bool executando = true;
        System.Console.WriteLine("===Welcome===");
        while (executando)
        {
            Console.WriteLine("\n1- Add task");
            Console.WriteLine("2- Complete task");
            Console.WriteLine("3- Display all tasks");
            Console.WriteLine("4- Edit task");
            Console.WriteLine("5- Remove task");
            Console.WriteLine("6- Exit");
            Console.Write("Choose: ");

            var option = ReadMenu();



            Menu menu = (Menu)option;
            switch (menu)
            {
                case Menu.Add:

                    AddTask(taskService);

                    break;
                case Menu.Complete:
                    CompleteTask(taskService);
                    break;

                case Menu.DisplayAll:
                    DisplayAll(taskService);
                    break;


                case Menu.Edit:
                    EditTask(taskService);
                    break;

                case Menu.Remove:
                    RemoveTask(taskService);
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

    // Validation

    static DateTime ReadDateTime()
    {
        DateTime dueDate;
        while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
        {
            System.Console.WriteLine("Invalid Date!");
        }

        return dueDate;
    }
    static string ReadString()
    {

        string entrada = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(entrada) || int.TryParse(entrada, out int a) || entrada.Length < 6)
        {
            System.Console.WriteLine("\nInvalid Description Minimum 6 Character\n");
            Console.Write("Enter task description:");
            entrada = Console.ReadLine();
        }

        return entrada;

    }



    static int ReadPriority()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input) || input > 3 || input <= 0)
        {
            System.Console.WriteLine("\nInvalid Charactere\n");
            System.Console.Write("Choose: ");
        }
        return input;
    }

    static int ReadMenu()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            System.Console.WriteLine("\nInvalid. Choose type 1 at 5\n");
            System.Console.Write("Choose: ");
        }
        return input;
    }

    static int ReadNumberTask(ITaskService taskService)
    {
        var task = taskService.GetAll();
        int input;
        while (!int.TryParse(Console.ReadLine(), out input) || input <= 0 || input > task.Count)
        {
            Console.WriteLine("Invalid Number Task! Try again...");
            Console.Write("Enter task number to edit: ");

        }
        return input;
    }

    // action

    //remove
    static void RemoveTask(ITaskService taskService)
    {
        Console.WriteLine("Here is a list of all your tasks:\n");
        DisplayAll(taskService);
        Console.Write("\nEnter task number to complete:");
        var taskNumber = ReadNumberTask(taskService);
        taskService.Remove(taskNumber);

    }
    
    //edit
    static void EditTask(ITaskService taskService)
    {
        Console.WriteLine("Here is a list of all your tasks:\n");
        DisplayAll(taskService);
        Console.Write("\nEnter task number to edit: ");
        int taskNumber = ReadNumberTask(taskService);

        Console.Write("\nEnter new task description:");
        var newDescription = ReadString();

        Console.WriteLine("\nEnter task priority:\n\n1- Low\n2- Midle\n3- High\n\nChoose: ");
        var newPriority = ReadPriority();

        System.Console.Write("Enter the new Due Date:");
        var newDueDate = ReadDateTime();

        taskService.Edit(index: taskNumber, newDescription: newDescription, newPriority: newPriority, newDueDate: newDueDate);
        Console.Clear();
    }

    //completar
    static void CompleteTask(ITaskService taskService)
    {
        Console.WriteLine("Here is a list of all your tasks:\n");
        DisplayAll(taskService);
        Console.Write("\nEnter task number to complete:");
        var taskNumber = ReadNumberTask(taskService);

        var ListOrdened = taskService.GetAll();
        TaskItem task = ListOrdened[taskNumber - 1];
        task.CompleteTask();
        //tasksComplete.Add(task);

        //RemoveTask(task);

        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        System.Console.WriteLine("\nCongratulations Task Completed!!!\n");
        Console.BackgroundColor = ConsoleColor.Black;
    }


    //mostrar
    static void DisplayAll(ITaskService taskService)
    {
        Console.Clear();
        var sortedTasks = taskService.GetAll();

        if (!sortedTasks.Any())
        {
            Console.WriteLine("\nNo tasks found.\n");
        }

        System.Console.WriteLine("=== Tasks ===\n");

        for (int i = 0; i < sortedTasks.Count; i++)
        {

            if (!sortedTasks[i].IsComplete)
            {
                Priority priority = (Priority)sortedTasks[i].Priority;
                Console.WriteLine($"{i + 1}. {sortedTasks[i].Description} - Incomplete - Priority: {priority} - Due Date: {sortedTasks[i].DueDate:dd/MM/yyyy}");
            }
        }

        System.Console.WriteLine();

        for (int i = 0; i < sortedTasks.Count; i++)
        {
            if (sortedTasks[i].IsComplete)
            {
                Priority priority = (Priority)sortedTasks[i].Priority;
                Console.WriteLine($"{i + 1}. {sortedTasks[i].Description} - Complete - Priority: {priority} - Due Date: {sortedTasks[i].DueDate:dd/MM/yyyy}");
            }
        }


    }

    // add

    static void AddTask(ITaskService taskService)
    {
        try
        {
            Console.Write("Enter task description: ");
            string description = ReadString();

            Console.Write("\nEnter task priority:\n\n1- Low\n2- Midle\n3- High\n\nChoose: ");
            int priority = ReadPriority();

            System.Console.Write("Enter the due date: ");
            DateTime dueDate = ReadDateTime();


            taskService.Add(description, priority, dueDate);
        }
        catch (ArgumentException ex)
        {
            System.Console.WriteLine($"\nError: {ex.Message}");
            System.Console.WriteLine($"Try Again.\n");
        }

    }
}


