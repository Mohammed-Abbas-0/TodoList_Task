using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Application.Commands.classes
{
    public class DeleteTodoListCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
