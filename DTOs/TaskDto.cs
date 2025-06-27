using System.ComponentModel.DataAnnotations;

namespace TaskManagementAPI.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = "Todo";
        public string Deadline { get; set; } = string.Empty; // Format: YYYY-MM-DD
    }

    public class CreateTaskDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = "Todo";

        [Required]
        public string Deadline { get; set; } = string.Empty; // Format: YYYY-MM-DD
    }

    public class UpdateTaskDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = "Todo";

        [Required]
        public string Deadline { get; set; } = string.Empty; // Format: YYYY-MM-DD
    }
}