using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Interface.Dtos;

namespace ToDoList.Interface.IRepositories
{
    public interface ITodoListServices
    {
        Task<ResponseMessage> CreateTodoList(CreateTodoListDto createTodoListDto);
        Task<ResponseMessage> EditTodoList(int id, EditTodoListDto editTodoListDto);
        Task<bool> DeleteTodoList(int id);
        Task<List<GetTodoListDto>> GetTodoList(FilterGetTodoList filterGetTodoList);
        Task<bool> Save();
        
    }
}
