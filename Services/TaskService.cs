using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementAPI.DTOs;
using TaskManagementAPI.Models;
using ModelTask = TaskManagementAPI.Models.Task;

namespace TaskManagementAPI.Services
{
    public interface ITaskService
    {
        Task<List<TaskDto>> GetAllTasksAsync();
        Task<TaskDto?> GetTaskByIdAsync(int id);
        Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto);
        Task<TaskDto?> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto);
        Task<bool> DeleteTaskAsync(int id);
    }

    public class TaskService : ITaskService
    {
        private static List<ModelTask> _tasks = new List<ModelTask>
           {
               new ModelTask { Id = 1, Name = "Design UI for Dashboard", Status = "In Progress", Deadline = new DateTime(2025, 6, 30), Description = "Create wireframes and mockups for the main dashboard interface" },
               new ModelTask { Id = 2, Name = "Write API Documentation", Status = "Todo", Deadline = new DateTime(2025, 7, 5), Description = "Document all REST API endpoints with examples and response formats" },
               new ModelTask { Id = 3, Name = "Fix bugs in Task Detail page", Status = "Complete", Deadline = new DateTime(2025, 6, 20), Description = "Resolve issues with task editing and form validation" },
               new ModelTask { Id = 4, Name = "Optimize database queries", Status = "In Progress", Deadline = new DateTime(2025, 7, 10), Description = "Improve performance of complex queries and add proper indexing" }
           };

        private static int _nextId = 5;

        public async Task<List<TaskDto>> GetAllTasksAsync()
        {
            var taskDtos = _tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Status = t.Status,
                Deadline = t.Deadline.ToString("yyyy-MM-dd")
            }).ToList();

            return await System.Threading.Tasks.Task.FromResult(taskDtos);
        }

        public async Task<TaskDto?> GetTaskByIdAsync(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return null;

            var taskDto = new TaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                Deadline = task.Deadline.ToString("yyyy-MM-dd")
            };

            return await System.Threading.Tasks.Task.FromResult(taskDto);
        }

        public async Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto)
        {
            var task = new ModelTask
            {
                Id = _nextId++,
                Name = createTaskDto.Name,
                Description = createTaskDto.Description,
                Status = createTaskDto.Status,
                Deadline = DateTime.Parse(createTaskDto.Deadline),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _tasks.Add(task);

            var taskDto = new TaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                Deadline = task.Deadline.ToString("yyyy-MM-dd")
            };

            return await System.Threading.Tasks.Task.FromResult(taskDto);
        }

        public async Task<TaskDto?> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return null;

            task.Name = updateTaskDto.Name;
            task.Description = updateTaskDto.Description;
            task.Status = updateTaskDto.Status;
            task.Deadline = DateTime.Parse(updateTaskDto.Deadline);
            task.UpdatedAt = DateTime.UtcNow;

            var taskDto = new TaskDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                Deadline = task.Deadline.ToString("yyyy-MM-dd")
            };

            return await System.Threading.Tasks.Task.FromResult(taskDto);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            _tasks.Remove(task);
            return await System.Threading.Tasks.Task.FromResult(true);
        }
    }
}