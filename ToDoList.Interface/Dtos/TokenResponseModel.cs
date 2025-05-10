using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Interface.Dtos
{
    public class TokenResponseModel : ResponseMessage
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
    }
}
