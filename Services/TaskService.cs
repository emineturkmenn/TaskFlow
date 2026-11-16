using Microsoft.EntityFrameworkCore;
using TaskFlow.Api.Data;
using TaskFlow.Api.DTOs.Tasks;
using TaskFlow.Api.Entities;
using TaskFlow.Api.Services.Interfaces;

namespace TaskFlow.Api.Services;

public class TaskService : ITaskService
{
    private readonly TaskFlowDbContext _context;

    public TaskService(TaskFlowDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItemDto> CreateAsync(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return new TaskItemDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt,
            DueDate = task.DueDate
        };
    }
}