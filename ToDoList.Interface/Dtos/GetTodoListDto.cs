using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;

namespace ToDoList.Interface.Dtos
{
    public record GetTodoListDto(
        int Id,
        string Title,
        string? Description,
        Status Status, 
        Priority Priority, 
        DateTime? DueDate,
        DateTime CreatedDate, 
        DateTime? LastModifiedDate 
        );
    
}
