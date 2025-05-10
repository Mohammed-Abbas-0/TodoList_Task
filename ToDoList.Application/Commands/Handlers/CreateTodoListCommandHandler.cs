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
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, ResponseMessage>
    {
        private readonly ITodoListServices _todoList;
        public CreateTodoListCommandHandler(ITodoListServices todoList)
        {
            _todoList = todoList;
        }
        public async Task<ResponseMessage> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var createTodoListDto = new CreateTodoListDto
            { 
                CreatedDate = DateTime.Now,
                Status = request.Status,
                Priority = request.Priority,
                Description = request.Description,
                Title = request.Title,
                DueDate = request.DueDate,

            };

            var response = await _todoList.CreateTodoList(createTodoListDto);
            return response;
        }
    }
}
