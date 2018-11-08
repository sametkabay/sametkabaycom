using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SametKabay.Application.Helpers;
using SametKabay.Application.UserServices.Dto;
using SametKabay.Core;
using SametKabay.Core;
using SametKabay.Core.Models;
using SametKabay.Core.Repositories;
using SametKabay.Core.Repositories.User;

namespace SametKabay.Application.UserServices
{
    public class UserAppServices : IUserAppServices
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _config;
        public UserAppServices(IMapper mapper, UserRepository userRepository, IConfiguration config)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _config = config;
        }
        public async Task CreateUser(CreateUserInputModel input)
        {
            var hashandSalt = PasswordHelper.HashPassword(input.Password);
            string[] splitData = hashandSalt.Split(':');
            var model = _mapper.Map<User>(input);
            model.PasswordHash = splitData[2];
            model.PasswordSalt = splitData[1];
            await _userRepository.Insert(model);

        }
        private string BuildToken(User user)
        {
            if (user.IsAdmin)
            {
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim("Admin", true.ToString()),
                 new Claim("UserId", user.Id.ToString())
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMonths(1),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Admin", false.ToString()),
                new Claim("UserId", user.Id.ToString())

                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMonths(1),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
        public async Task<LoginOutputModel> Login(LoginInputModel input)
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(
                    p => p.UserName == input.UserNameOrEmail ||
                    p.Email == input.UserNameOrEmail);

            if (user == null)
            {
                throw new KeyNotFoundException();
            }
            var hashSaltandIteration = 1000 + ":" + user.PasswordSalt + ":" + user.PasswordHash;
            var isValidate = PasswordHelper.ValidatePassword(input.Password, hashSaltandIteration);
            if (isValidate)
            {
                var model = new LoginOutputModel
                {
                    Token = BuildToken(user),
                    Id = user.Id,
                    IsAdmin = user.IsAdmin
                };
                //BackgroundJob.Enqueue(() => SendMailHelper.SendMail("kullanıcı giriş yaptı"));
                return model;
            }

            return new LoginOutputModel();

        }
    }
}
