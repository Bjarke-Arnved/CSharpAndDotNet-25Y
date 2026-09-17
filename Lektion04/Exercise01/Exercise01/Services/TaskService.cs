using Exercise01.Models.DTOs;
using Exercise01.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Exercise01.Services
{
        public interface ITaskService
        {
                public Task<List<TaskDto>> GetAllAsync();
                public Task<TaskDto> GetByIdAsync(string id);
                public Task<TaskDto> CreateTaskAsync(CreateTaskDto dto);
                public Task<TaskDto> UpdateTaskAsync(string id, UpdateTaskDto dto);
                public Task<bool> DeleteTaskAsync(string id);
        }
        public class TaskService : ITaskService
        {
                private static List<TaskItem> _dummyData = new([
                        new TaskItem("sdgjoi325jkldfj", "Drink water", "at 8:00, 12:00, 18:00", false),
                        new TaskItem("sdgjowi334", "Buy groseries", "Eggs, Milk, Bread, Butter", true)
                        ]);

                public async Task<List<TaskDto>> GetAllAsync()
                {
                        List<TaskDto> exportList = new();
                        _dummyData.ForEach(t => exportList.Add(t.ToDto()));
                        return exportList;
                }
                public Task<TaskDto> GetByIdAsync(string id)
                {
                        var task = _dummyData.FirstOrDefault(t => t.Id.Equals(id));
                        return Task.FromResult(task.ToDto());
                }
                public async Task<TaskDto> CreateTaskAsync(CreateTaskDto dto)
                {
                        TaskDto newDto = new (Guid.NewGuid().ToString(), dto.Title, dto.Description, dto.IsCompleted, DateTime.Now);
                        _dummyData.Add(TaskItem.FromDto(newDto));
                        return newDto;
                }
                public async Task<TaskDto> UpdateTaskAsync(string id, UpdateTaskDto dto)
                {
                        var taskToUpdate = _dummyData.FirstOrDefault(t => t.Id == id);
                        if (taskToUpdate != null)
                        {
                                taskToUpdate.Title = dto.Title;
                                taskToUpdate.IsCompleted = dto.IsCompleted;
                                taskToUpdate.Description = dto.Description;
                        }
                        return taskToUpdate.ToDto();
                }
                public async Task<bool> DeleteTaskAsync(string id)
                {
                        var index = _dummyData.IndexOf(_dummyData.FirstOrDefault(t => t.Id == id));
                        if (_dummyData[index] != null)
                        {
                                _dummyData.RemoveAt(index);
                                return true;
                        }
                        return false;
                }
        }
}
