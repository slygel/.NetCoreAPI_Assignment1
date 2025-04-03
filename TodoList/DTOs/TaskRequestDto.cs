namespace TodoList.DTOs;

public class TaskRequestDto
{
    public string? Title { get; set; }
    public bool IsCompleted { get; set; }
}