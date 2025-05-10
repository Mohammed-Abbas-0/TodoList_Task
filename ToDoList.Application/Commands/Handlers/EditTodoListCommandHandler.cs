using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Commands.classes;
using ToDoList.Interface.Dtos;
using ToDoList.Interface.IRepositories;

namespace ToDoList.Application.Commands.Handlers
{
    public class EditTodoListCommandHandler : IRequestHandler<EditTodoListCommand, ResponseMessage>
    {
        private readonly ITodoListServices _todoList;
        public EditTodoListCommandHandler(ITodoListServices todoList)
        {
            _todoList = todoList;
        }
        public async Task<ResponseMessage> Handle(EditTodoListCommand request, CancellationToken cancellationToken)
        {
            var editTodoListDto = new EditTodoListDto
            {
                CreatedDate = DateTime.Now,
                Status = request.Status,
                Priority = request.Priority,
                Description = request.Description,
                Title = request.Title,
                DueDate = request.DueDate,

            };

            var response = await _todoList.EditTodoList(request.Id,editTodoListDto);
            return response;
        }
    }
}
