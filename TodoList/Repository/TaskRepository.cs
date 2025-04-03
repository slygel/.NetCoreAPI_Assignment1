using System.Text.Json;
using TodoList.Entites;

namespace TodoList.Repository;

public class TaskRepository : ITaskRepository
{
    private readonly string _filePath;

    public TaskRepository(IConfiguration configuration)
    {
        _filePath = configuration.GetValue<string>("DataFilePath") ?? "Data/tasks.json";
    }

    public List<TaskItem> GetAllTasks()
    {
        if (!File.Exists(_filePath))
        {
            return new List<TaskItem>();
        }

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    public void SaveTasks(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}