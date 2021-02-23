using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Services
{
    public class HttpContextUserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public HttpContextUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public User GetCurrentUser()
        {
            return new User()
            {
                UserId = "90562083-58dc-4d09-9bad-18133940877b",
                FirstName = "Austin",
                LastName = "Bach",
                Role = "Admin"
            };
            return _httpContextAccessor.HttpContext.User as User;
        }
    }
}
