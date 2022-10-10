using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class BlogDal : EfEntityRepositoryBase<Blog, TechBlogDbContext>, IBlogDal
    {
        public List<Blog> GetAllBlogIncludeCategory()
        {
            using var _context = new TechBlogDbContext();
            var blogs = _context.Blogs.Include(x => x.Category).ToList();
            return blogs;
        }
        public Blog GetBlogIncludeCategory(int id)
        {
            using var _context = new TechBlogDbContext();
            var blog = _context.Blogs.Include(x => x.Category).FirstOrDefault();
            return blog;
        }
       
    }
}
