using System.Text.Json;
using System.Text.Json.Serialization;
namespace TaskApp;

public class TaskManager
{
    [JsonInclude] public List<CustomTask> tasksList = new List<CustomTask>();

    public TaskManager()
    {

    }

    public void AddTask(CustomTask task)
    {
        tasksList.Add(task);
    }

    public void RemoveTask(CustomTask task)
    {
        tasksList.Remove(task);
    }

    public void UpdateTask(int taskId, TaskStatus status)
    {
        
    }

    public void PrintTasks()
    {
        foreach (var customTask in tasksList)
        {
            Console.WriteLine($"-{customTask.TaskId}-  {customTask.TaskName} : {customTask.TaskStatus}");
        }
    }
    
    public void SaveTasksToFile(string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(tasksList, options);
        File.WriteAllText(filePath, json);
    }

    public void LoadTasksFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found");
            return;
        }

        string json = File.ReadAllText(filePath);
        tasksList = JsonSerializer.Deserialize<List<CustomTask>>(json);
        
        if (tasksList.Count > 0)
        {
            int maxId = 0;

            foreach (CustomTask t in tasksList)
            {
                if (t.TaskId > maxId)
                {
                    maxId = t.TaskId;
                }
            }
            CustomTask.SetNextId(maxId + 1);
        }

    }

}