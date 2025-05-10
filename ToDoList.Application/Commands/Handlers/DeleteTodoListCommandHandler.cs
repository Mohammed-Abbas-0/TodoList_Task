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
    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand, bool>
    {
        private readonly ITodoListServices _todoList;
        public DeleteTodoListCommandHandler(ITodoListServices todoList)
        {
            _todoList = todoList;
        }
        public async Task<bool> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var response = await _todoList.DeleteTodoList(request.Id);
            return response;
        }
    }
}
