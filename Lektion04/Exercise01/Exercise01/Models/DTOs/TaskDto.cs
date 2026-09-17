using System.ComponentModel;

namespace Exercise01.Models.DTOs
{
        public record TaskDto(string Id, string Title, string Description, bool IsCompleted, DateTime CreatedAt);
        
}
