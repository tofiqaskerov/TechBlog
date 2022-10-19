using Business.Abstract;
using Core.Entity.Models;
using Core.Security.Hashing;
using Core.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(LoginDTO loginDTO)
        {
            var checkUser = _userService.GetByEmail(loginDTO.Email);
            var checkPassword = HashingHelper.VerifyPassword(loginDTO.Password, checkUser.PasswordHash, checkUser.PasswordSalt);

            if (checkUser == null) return null;
            if (!checkPassword) return null;

            var token = TokenGenerator.Token(checkUser, "User");

            return token;
        }

        public void Register(RegisterDTO registerDTO)
        {
            if(registerDTO.Password == registerDTO.PasswordRepeat)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.HashPassword(registerDTO.Password, out passwordHash, out passwordSalt);
                User user = new()
                {
                    Email = registerDTO.Email,
                    Name = registerDTO.Name,
                    Surname = registerDTO.Surname,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
                _userService.Add(user);
                
            }
           
           
        }
    }
}
