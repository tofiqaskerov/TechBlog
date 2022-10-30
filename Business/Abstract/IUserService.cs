﻿using Core.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User GetByEmail(string email);
        List<User> GetAll();
    }
}
