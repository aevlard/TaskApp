using System;
using TaskApp;
using TaskStatus = TaskApp.TaskStatus;

int currentUserInput = 0;

TaskManager myTaskManager = new TaskManager();

myTaskManager.LoadTasksFromFile("tasks.json");

Console.WriteLine("Bienvenue sur votre TODO List !");
ShowMenu();

void ShowMenu()
{
    Console.WriteLine("QUE VOULEZ VOUS FAIRE ?????");
    Console.WriteLine("1. AJOUTER UNE TACHE");
    Console.WriteLine("2. MODIFIER UNE TACHE");
    Console.WriteLine("3. VALIDER UNE TACHE");
    Console.WriteLine("4. AFFICHER VOS TACHE");
    WaitInput();
}

void WaitInput()
{
    int currentUserInput = Convert.ToInt32(Console.ReadLine());

    switch (currentUserInput)
    {
        case 1:
            HandleAddTask();
            break;
        case 2:
            HandleUpdateTask();
            break;
        case 3:
            HandleEndTask();
            break;
        case 4:
            HandleShowTasks();
            break;
        default:
            Console.WriteLine("Choix invalide");
            ShowMenu();
            WaitInput();
            break;
    }
}

void HandleAddTask()
{
    Console.WriteLine("Entrez le nom de la tâche");
    string taskName = Console.ReadLine();
    
    Console.WriteLine("Entrez la description de la tâche");
    string taskDescription = Console.ReadLine();
    
    CustomTask newTask = new CustomTask(taskName, taskDescription);
    myTaskManager.AddTask(newTask);
    
    Console.WriteLine("Tâche ajouter avec succes");
    myTaskManager.SaveTasksToFile("tasks.json");
    
    ShowMenu();
}

void HandleUpdateTask()
{
    Console.WriteLine("Entrez l'id de la tache que vous voulez modifier");
    int taskIdToUpdate = Convert.ToInt32(Console.ReadLine());
    
    Console.WriteLine("Entrez le nouveau nom de la tâche");
    string newTaskName = Console.ReadLine();
    
    Console.WriteLine("Entrez la nouvelle description de la tâche");
    string newTaskDescription = Console.ReadLine();

    foreach (CustomTask customTask in myTaskManager.tasksList)
    {
        if (customTask.TaskId == taskIdToUpdate)
        {
            customTask.TaskName = newTaskName;
            customTask.TaskDescription = newTaskDescription;
            break;
        }
    }
    myTaskManager.SaveTasksToFile("tasks.json");
    ShowMenu();
}

void HandleEndTask()
{
    CustomTask taskIdToEnd = SelectTask();

    taskIdToEnd.TaskStatus = TaskStatus.Done;
    
    Console.WriteLine("Statut de la tâche modifier avec succes");
    myTaskManager.SaveTasksToFile("tasks.json");
    ShowMenu();
}

void HandleShowTasks()
{
    myTaskManager.PrintTasks();
    ShowMenu();
}

CustomTask SelectTask()
{
    Console.WriteLine("Entrez l'id de la tache que vous marquer comme terminer");
    int taskIdToUpdate = Convert.ToInt32(Console.ReadLine());
    
    foreach (CustomTask customTask in myTaskManager.tasksList)
    {
        if (customTask.TaskId == taskIdToUpdate)
        {
            return customTask;
            break;
        }
    }
    return null;
}



