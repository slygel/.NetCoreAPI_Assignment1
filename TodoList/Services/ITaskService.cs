using TodoList.DTOs;
using TodoList.Entites;

namespace TodoList.Services;

public interface ITaskService
{
    List<TaskResponseDto?> GetAllTasks();
    TaskResponseDto? GetTaskById(string id);
    TaskResponseDto? CreateTask(TaskRequestDto taskDto);
    bool UpdateTask(string id, TaskRequestDto taskDto);
    bool DeleteTask(string id);
    List<TaskResponseDto?> CreateBulkTasks(List<TaskRequestDto> taskDtos);
    bool DeleteBulkTasks(List<string> ids);
}