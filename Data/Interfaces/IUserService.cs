﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IUserService
    {
        User GetCurrentUser();
    }
}
