using System.ComponentModel.DataAnnotations;
using Exercise01.Models.DTOs;

namespace Exercise01.Models
{
        public class TaskItem
        {
                [Required]
                public string Id { get; init; }
                [Required]
                public string Title { get; set; }
                public string? Description { get; set; }
                public bool IsCompleted { get; set; }
                public DateTime CreatedAt { get; set; }
                public TaskItem(string id, string title, string description, bool isCompleted)
                {
                        Id = id;
                        Title = title;
                        Description = description;
                        IsCompleted = isCompleted;
                        CreatedAt = DateTime.Now;
                }
                private TaskItem(string id, string title, string description, bool isCompleted, DateTime createdAt)
                {
                        Id = id;
                        Title = title;
                        Description = description;
                        IsCompleted = isCompleted;
                        CreatedAt = createdAt;
                }
                public TaskDto ToDto()
                {
                        return new TaskDto(Id, Title, Description, IsCompleted, CreatedAt);
                }
                public static TaskItem FromDto(TaskDto dto)
                {
                        return new TaskItem(dto.Id, dto.Title, dto.Description, dto.IsCompleted, dto.CreatedAt);
                }
        }
}
