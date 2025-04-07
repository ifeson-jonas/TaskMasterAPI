namespace TaskMasterAPI.Interfaces.Services;

public interface ITaskService
{
    Task<ServiceResult<TaskItem>> CreateTaskAsync(TaskItem task, int userId);
    Task<ServiceResult<TaskItem>> UpdateTaskAsync(int id, TaskItem task, int userId);
    Task<ServiceResult<bool>> DeleteTaskAsync(int id, int userId);
    Task<ServiceResult<TaskItem>> GetTaskAsync(int id, int userId);
    Task<ServiceResult<IEnumerable<TaskItem>>> GetAllUserTasksAsync(int userId);
}

public class ServiceResult<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public int StatusCode { get; set; }
}

