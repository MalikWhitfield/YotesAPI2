using Common.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
    /// <summary>
    /// 
    /// </summary>
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
            return _httpContextAccessor.HttpContext.User as User;
        }
    }
}
