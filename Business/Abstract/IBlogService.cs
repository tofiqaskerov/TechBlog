﻿using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
        List<Blog> GetAll();
        Blog GetById(int id);
        Blog GetBlogIncludeCategory(int id);
        List<Blog> GetAllBlogIncludeCategory();
    }
}
