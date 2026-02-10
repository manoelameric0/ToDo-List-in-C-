using System;

namespace TodoListN;

public class ToDoList
{
    private List<Task> tasks;

        public ToDoList()
        {
            tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void CompleteTask(int taskNumber)
        {
            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                tasks[taskNumber].CompleteTask();
            }
        }

        public void RemoveTask(int taskNumber)
        {
            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                tasks.RemoveAt(taskNumber);
            }
        }

        public void DisplayTasks()
        {
            var sortedTasks = tasks.OrderBy(t => t.Priority).ToList();
            for (int i = 0; i < sortedTasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedTasks[i].Description} - {(sortedTasks[i].IsComplete ? "Complete" : "Incomplete")} - Priority: {sortedTasks[i].Priority}");
            }
        }

        public void EditTask(int taskNumber)
        {
            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                Console.WriteLine("Enter new task description:");
                var newDescription = Console.ReadLine();
                Console.WriteLine("Enter new task priority:");
                var newPriority = int.Parse(Console.ReadLine());
                tasks[taskNumber].Description = newDescription;
                tasks[taskNumber].Priority = newPriority;
            }
        }

    
}
