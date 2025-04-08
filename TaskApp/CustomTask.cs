namespace TaskApp;

public class CustomTask
{
    private static int nextId = 1;
    
    private int taskId;
    private string taskName;
    private string taskDescription;
    private TaskStatus taskStatus;

    public CustomTask(string taskName, string taskDescription)
    {
        this.taskId = nextId++;
        this.taskName = taskName;
        this.taskDescription = taskDescription;
        this.taskStatus = TaskStatus.Pending;
    }
    
    public static void SetNextId(int value)
    {
        nextId = value;
    }
    public int TaskId
    {
        get => taskId;
        set => taskId = value;
    }
    public string TaskName
    {
        get => taskName;
        set => taskName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string TaskDescription
    {
        get => taskDescription;
        set => taskDescription = value ?? throw new ArgumentNullException(nameof(value));
    }

    public TaskStatus TaskStatus
    {
        get => taskStatus;
        set => taskStatus = value;
    }
}

public enum TaskStatus
{
    Pending,
    Running,
    Done,
}