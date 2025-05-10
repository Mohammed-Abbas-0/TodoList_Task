using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Context;
using ToDoList.Interface.Dtos;
using ToDoList.Interface.IRepositories;

namespace ToDoList.Infrastructure.Repositories
{
    public class TodoListServices : ITodoListServices
    {
        private readonly AppDbContext _db;
        public TodoListServices(AppDbContext db)
        {
            _db = db;
        }
        public async Task<ResponseMessage> CreateTodoList(CreateTodoListDto createTodoListDto)
        {
            var createTodoList = new Todolist 
            { 
                CreatedDate = DateTime.Now,
                Description = createTodoListDto.Description,
                Title = createTodoListDto.Title,
                DueDate = createTodoListDto.DueDate,
                Status = createTodoListDto.Status,
                Priority = createTodoListDto.Priority, 
            };
            await _db.todolists.AddAsync(createTodoList);
            bool isSuccess = await Save();
            if(!isSuccess)
                return new ResponseMessage { Success = false,Message="Try again!" };

            return new ResponseMessage { Success = true,Message = "Created is Successfully"};
        }

        public async Task<bool> DeleteTodoList(int id)
        {
            
            var todolist = await _db.todolists.FindAsync(id);
            if(todolist is null)
                return false;

            _db.todolists.Remove(todolist);
           return await Save();
        }

        public async Task<ResponseMessage> EditTodoList(int id,EditTodoListDto editTodoListDto)
        {
            var todolist = await _db.todolists.FindAsync(id);

            if (todolist is null)
                return new ResponseMessage { Success = false, Message = "Todo list not Found" };


            todolist.Description = editTodoListDto.Description;
            todolist.Title = editTodoListDto.Title;
            todolist.DueDate = editTodoListDto.DueDate;
            todolist.Status = editTodoListDto.Status;
            todolist.Priority = editTodoListDto.Priority;
            todolist.LastModifiedDate = DateTime.Now;
           
            bool isSuccess = await Save();
            if (!isSuccess)
                return new ResponseMessage { Success = false, Message = "Try again!" };

            return new ResponseMessage { Success = true, Message = "Edited is Successfully" };
        }

        public async Task<List<GetTodoListDto>> GetTodoList(FilterGetTodoList filter)
        {
            var query = _db.todolists.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Title))
                query = query.Where(x => x.Title.Contains(filter.Title));

            if (filter.Status != null)
                query = query.Where(x => x.Status == filter.Status);

            if (filter.Priority != null)
                query = query.Where(x => x.Priority == filter.Priority);

            if (filter.DueDate != null)
            {
                var date = filter.DueDate.Value.Date;
                query = query.Where(x => x.DueDate >= date && x.DueDate < date.AddDays(1));
            }

            query = query.OrderByDescending(x => x.Id);

            if (filter.PageSize.HasValue && filter.PageCount.HasValue)
            {
                int skip = (filter.PageCount.Value - 1) * filter.PageSize.Value;
                query = query.Skip(skip).Take(filter.PageSize.Value);
            }

            var todolists = await query.ToListAsync();
            return todolists.Select(todo => new GetTodoListDto(
                todo.Id,
                todo.Title,
                todo.Description,
                todo.Status,
                todo.Priority,
                todo.DueDate,
                todo.CreatedDate,
                todo.LastModifiedDate
            )).ToList();


            //List<GetTodoListDto> getTodoListDtos = new List<GetTodoListDto>();
            //foreach(var todo in todolists)
            //{
            //    var GetTodoListDto = new GetTodoListDto(
            //                 Id: todo.Id,
            //                 Title: todo.Title,
            //                 Description: todo.Description,
            //                 Status: todo.Status,
            //                 Priority: todo.Priority,
            //                 DueDate: todo.DueDate,
            //                 CreatedDate: todo.CreatedDate,
            //                 LastModifiedDate: todo.LastModifiedDate
            //             );


            //    getTodoListDtos.Add(GetTodoListDto);
            //}
            //return getTodoListDtos;


        }




        public async Task<bool> Save() => await _db.SaveChangesAsync() > 0;
        
    }
}
