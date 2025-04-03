using TodoList.DTOs;
using TodoList.Entites;

namespace TodoList.Mappers;

public class TaskMapper : ITaskMapper
{
    public TaskResponseDto? ToResponseDto(TaskItem task)
    {
        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            IsCompleted = task.IsCompleted
        };
    }
    
    public TaskItem ToTaskItem(TaskRequestDto createDto)
    {
        return new TaskItem
        {
            Title = createDto.Title,
            IsCompleted = createDto.IsCompleted
        };
    }
    
    public void UpdateTaskItem(TaskItem task, TaskRequestDto updateDto)
    {
        task.Title = updateDto.Title;
        task.IsCompleted = updateDto.IsCompleted;
    }
}