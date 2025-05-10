using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Entities
{
    public enum Status
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2
    }

    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2
    }

    public class Todolist
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public required string Title { get; set; }
        public string? Description { get; set; } = string.Empty;

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; }

    }
}
