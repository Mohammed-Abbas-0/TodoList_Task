using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;

namespace ToDoList.Interface.Dtos
{
    public class FilterGetTodoList
    {
        public int? Id {  get; set; }
        public string? Title { get; set; }
        public DateTime? DueDate { get; set; }
        public Status? Status { get; set; }

        public Priority? Priority { get; set; }
        public int? PageSize { get; set; } = 1;
        public int? PageCount { get; set; } = 10;
    }
}
