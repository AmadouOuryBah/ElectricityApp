﻿
using Electricity.BusinessLogic.DTO_s;
using Electricity.BusinessLogic.Requests;
using Electricity.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Electricity.BusinessLogic.Services.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetById(int id);
        Task<UserDto> AddAsync(UserRegister user);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<string> DeleteAsync(int id);
<<<<<<< HEAD
        Task AuthenticateAsync(string username, string role);
        Task Register(UserRequest user);

        Task Login(UserRequest user);
=======
        Task<User> LoginAsync(string username, string password);

        Task AuthenticateAsync(HttpContext context, string username, string role);
        
           
       
>>>>>>> 6659714e66f502cc2e70f365b19c0c55dff71312
    }
}
