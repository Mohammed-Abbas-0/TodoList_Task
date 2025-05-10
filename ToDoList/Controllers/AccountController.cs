using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Interface.Dtos;
using ToDoList.Interface.IRepositories;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthLogin _authLogin;
        public AccountController(IAuthLogin authLogin)
        {
            _authLogin = authLogin;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModelDto user)
        {
            var response =  _authLogin.LoginAsync(user);
            return Ok(response);
        }
    }
}
