using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IUserService
    {
        User GetCurrentUser();
    }
}
