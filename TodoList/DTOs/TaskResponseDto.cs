namespace TodoList.DTOs;

public class TaskResponseDto
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public bool IsCompleted { get; set; }
}