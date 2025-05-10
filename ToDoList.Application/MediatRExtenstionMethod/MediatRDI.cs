using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Commands.classes;
using ToDoList.Application.Commands.Handlers;

namespace ToDoList.Application.MediatRExtenstionMethod
{
    public static class MediatRDI
    {
        public static IServiceCollection AddMediatRDependency(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddMediatR(idx => idx.RegisterServicesFromAssembly(typeof(CreateTodoListCommandHandler).Assembly));
            Services.AddMediatR(idx => idx.RegisterServicesFromAssembly(typeof(EditTodoListCommandHandler).Assembly));
            Services.AddMediatR(idx => idx.RegisterServicesFromAssembly(typeof(DeleteTodoListCommandHandler).Assembly));

            return Services;

        }
    }
}
