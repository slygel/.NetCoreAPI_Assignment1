using TodoList.Entites;

namespace TodoList.Repository;

public interface ITaskRepository
{
    List<TaskItem> GetAllTasks();
    void SaveTasks(List<TaskItem> tasks);
}