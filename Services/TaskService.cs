using TaskMasterAPI.Interfaces.Repositories;
using TaskMasterAPI.Interfaces.Services;
using TaskMasterAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskMasterAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ServiceResult<TaskItem>> CreateTaskAsync(TaskItem task, int userId)
        {
            try
            {
                task.UserId = userId;
                await _taskRepository.AddAsync(task);
                return new ServiceResult<TaskItem> { Success = true, Data = task };
            }
            catch (System.Exception ex)
            {
                return new ServiceResult<TaskItem> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<ServiceResult<TaskItem>> UpdateTaskAsync(int id, TaskItem task, int userId)
        {
            try
            {
                var existingTask = await _taskRepository.GetByIdAsync(id);
                if (existingTask == null || existingTask.UserId != userId)
                    return new ServiceResult<TaskItem> { Success = false, ErrorMessage = "Task not found or unauthorized" };

                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.IsCompleted = task.IsCompleted;
                existingTask.Priority = task.Priority;

                await _taskRepository.UpdateAsync(existingTask);
                return new ServiceResult<TaskItem> { Success = true, Data = existingTask };
            }
            catch (System.Exception ex)
            {
                return new ServiceResult<TaskItem> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<ServiceResult<bool>> DeleteTaskAsync(int id, int userId)
        {
            try
            {
                var existingTask = await _taskRepository.GetByIdAsync(id);
                if (existingTask == null || existingTask.UserId != userId)
                    return new ServiceResult<bool> { Success = false, ErrorMessage = "Task not found or unauthorized", Data = false };

                await _taskRepository.DeleteAsync(id);
                return new ServiceResult<bool> { Success = true, Data = true };
            }
            catch (System.Exception ex)
            {
                return new ServiceResult<bool> { Success = false, ErrorMessage = ex.Message, Data = false };
            }
        }

        public async Task<ServiceResult<TaskItem>> GetTaskAsync(int id, int userId)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(id);
                if (task == null || task.UserId != userId)
                    return new ServiceResult<TaskItem> { Success = false, ErrorMessage = "Task not found or unauthorized" };

                return new ServiceResult<TaskItem> { Success = true, Data = task };
            }
            catch (System.Exception ex)
            {
                return new ServiceResult<TaskItem> { Success = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<ServiceResult<IEnumerable<TaskItem>>> GetAllUserTasksAsync(int userId)
        {
            try
            {
                var tasks = await _taskRepository.GetByUserIdAsync(userId);
                return new ServiceResult<IEnumerable<TaskItem>> { Success = true, Data = tasks };
            }
            catch (System.Exception ex)
            {
                return new ServiceResult<IEnumerable<TaskItem>> { Success = false, ErrorMessage = ex.Message };
            }
        }
    }
}
