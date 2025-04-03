using TodoList.DTOs;
using TodoList.Entites;
using TodoList.Mappers;
using TodoList.Repository;

namespace TodoList.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly TaskMapper _mapper;
    
    public TaskService(ITaskRepository taskRepository, TaskMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
    
    public List<TaskResponseDto?> GetAllTasks()
    {
        var tasks = _taskRepository.GetAllTasks();
        return tasks.Select(_mapper.ToResponseDto).ToList();
    }

    public TaskResponseDto? GetTaskById(string id)
    {
        var tasks = _taskRepository.GetAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);
        return task != null ? _mapper.ToResponseDto(task) : null;
    }

    public TaskResponseDto? CreateTask(TaskRequestDto taskDto)
    {
        var tasks = _taskRepository.GetAllTasks();
        var task = _mapper.ToTaskItem(taskDto);
        tasks.Add(task);
        _taskRepository.SaveTasks(tasks);
        return _mapper.ToResponseDto(task);
    }

    public bool UpdateTask(string id, TaskRequestDto taskDto)
    {
        var tasks = _taskRepository.GetAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;

        task.Title = taskDto.Title;
        task.IsCompleted = taskDto.IsCompleted;
        _taskRepository.SaveTasks(tasks);
        return true;
    }

    public bool DeleteTask(string id)
    {
        var tasks = _taskRepository.GetAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;

        tasks.Remove(task);
        _taskRepository.SaveTasks(tasks);
        return true;
    }

    public List<TaskResponseDto?> CreateBulkTasks(List<TaskRequestDto> taskDtos)
    {
        var tasks = _taskRepository.GetAllTasks();
        var newTasks = taskDtos.Select(_mapper.ToTaskItem).ToList();

        tasks.AddRange(newTasks);
        _taskRepository.SaveTasks(tasks);
        return newTasks.Select(_mapper.ToResponseDto).ToList();
    }

    public bool DeleteBulkTasks(List<string> ids)
    {
        var tasks = _taskRepository.GetAllTasks();
        var initialCount = tasks.Count;
        tasks.RemoveAll(t => ids.Contains(t.Id));
        _taskRepository.SaveTasks(tasks);
        return tasks.Count < initialCount;
    }
}