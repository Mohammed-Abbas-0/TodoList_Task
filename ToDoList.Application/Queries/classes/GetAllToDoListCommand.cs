using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Interface.Dtos;

namespace ToDoList.Application.Queries.classes
{
    public class GetAllToDoListCommand:IRequest<List<GetTodoListDto>>
    {
    }
}
