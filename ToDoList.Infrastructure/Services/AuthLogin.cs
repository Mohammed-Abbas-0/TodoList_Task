using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Infrastructure.Context;
using ToDoList.Interface.Dtos;
using ToDoList.Interface.IRepositories;

namespace ToDoList.Infrastructure.Services
{
    public class AuthLogin : IAuthLogin
    {
        private readonly AppDbContext _db;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthLogin(AppDbContext db, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public ResponseMessage LoginAsync(LoginModelDto loginModel)
        {
            if (loginModel.Email != "Test@test.c")
                return new ResponseMessage { Message = "البريد او الباسورد خطأ", Success = false };

            if (loginModel.Password != "123456Ee*")
                return new ResponseMessage { Message = "البريد او الباسورد خطأ", Success = false };

            string token =  _jwtTokenGenerator.GenerateJwtToken(loginModel);

           

            return new TokenResponseModel
            {
                Success = true,
                Message = "تم تسجيل الدخول",
                Token = token,
                Email = loginModel.Email ?? "",
               
            };
        }

    }
}
