using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0309.Models
{
    public class UserTask
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; } // Foreign Key
        public Category? Category { get; set; } // Navigation Property

        public bool Completed { get; set; }
    }
}
