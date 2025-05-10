using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Interface.Dtos
{
    public class LoginModelDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
