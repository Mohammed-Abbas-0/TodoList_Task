using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Commands.classes;
using ToDoList.Application.Queries.classes;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodoListController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #region Create  ToDoList
        [Authorize]

        [HttpPost("create")]
        public async Task<IActionResult> CreateToDoList([FromBody] CreateTodoListCommand createTodoListCommand)
        {
            var response = await _mediator.Send(createTodoListCommand);
            return Ok(response);
        }
        #endregion

        #region Edit  ToDoList
        [HttpPost("edit")]
        public async Task<IActionResult> EditToDoList([FromBody] EditTodoListCommand editTodoListCommand)
        {
            var response = await _mediator.Send(editTodoListCommand);
            return Ok(response);
        }
        #endregion

        #region Delete  ToDoList
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            var deleteTodoListCommand = new DeleteTodoListCommand { Id = id};
            var response = await _mediator.Send(deleteTodoListCommand);
            return Ok(response);
        }
        #endregion

        #region Get  ToDoList
        [HttpPost("getall")]
        public async Task<IActionResult> GetToDoList([FromBody] GetAllToDoListCommand getAllToDoListCommand)
        {
            var response = await _mediator.Send(getAllToDoListCommand);
            return Ok(response);
        }
        #endregion

    }
}
