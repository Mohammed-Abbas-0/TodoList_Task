using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Interface.Dtos;

namespace ToDoList.Interface.IRepositories
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(LoginModelDto user);
    }
}
