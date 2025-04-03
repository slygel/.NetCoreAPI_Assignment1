using TodoList.DTOs;
using TodoList.Entites;

namespace TodoList.Mappers;

public interface ITaskMapper
{
    TaskResponseDto? ToResponseDto(TaskItem task);
    TaskItem ToTaskItem(TaskRequestDto createDto);
    void UpdateTaskItem(TaskItem task, TaskRequestDto updateDto);
}