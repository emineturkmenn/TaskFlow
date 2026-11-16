using TaskFlow.Api.DTOs.Tasks;

namespace TaskFlow.Api.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskItemDto> CreateAsync(CreateTaskDto dto);
    }
}
