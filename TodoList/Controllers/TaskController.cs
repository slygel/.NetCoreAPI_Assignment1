using Microsoft.AspNetCore.Mvc;
using TodoList.DTOs;
using TodoList.Services;

namespace TodoList.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpGet]
    public IActionResult GetAllTasks()
    {
        var tasks = _taskService.GetAllTasks();
        return Ok(tasks);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetTask(string id)
    {
        var task = _taskService.GetTaskById(id);
        if (task == null) return NotFound();
        return Ok(task);
    }

    [HttpPost]
    public IActionResult CreateTask([FromBody] TaskRequestDto taskDto)
    {
        var createdTask = _taskService.CreateTask(taskDto);
        return CreatedAtAction(nameof(GetTask), new { id = createdTask?.Id }, createdTask);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(string id, [FromBody] TaskRequestDto taskDto)
    {
        var result = _taskService.UpdateTask(id, taskDto);
        if (!result) return NotFound();
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(string id)
    {
        var result = _taskService.DeleteTask(id);
        if (!result) return NotFound();
        return Ok(result);
    }

    [HttpPost("bulk")]
    public IActionResult CreateBulkTasks([FromBody] List<TaskRequestDto> taskDtos)
    {
        var createdTasks = _taskService.CreateBulkTasks(taskDtos);
        return Ok(createdTasks);
    }

    [HttpDelete("bulk")]
    public IActionResult DeleteBulkTasks([FromBody] List<string> ids)
    {
        var result = _taskService.DeleteBulkTasks(ids);
        if (!result) return NotFound();
        return Ok(result);
    }
}