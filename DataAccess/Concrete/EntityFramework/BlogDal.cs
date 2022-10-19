using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
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
            var blog = _context.Blogs.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            return blog;
        }

        public List<Blog> GetLastThreeBlog()
        {
            using var _context = new TechBlogDbContext();
            var lastThreeBlog = _context.Blogs.Include(x => x.Category).OrderByDescending(x => x.Id).Take(3).ToList();

            return lastThreeBlog;
        }

        public NextPrevBlogDTO GetNextPrevBlog(int id)
        {
            using var _context = new TechBlogDbContext();
            var nextBlog = _context.Blogs.SkipWhile(x => x.Id != id).Skip(1).First();
            var prevBlog = _context.Blogs.TakeWhile(x => x.Id != id).Last();

             
            return null;   /// coming soon......///
            

        }

        public List<PopularBlogDTO> GetPopularBlogs()
        {
            using var _context = new TechBlogDbContext();
            var popularBlog = _context.Blogs.Include(x => x.Category).OrderByDescending(x => x.Hit).Select(b => new PopularBlogDTO
            {
                Id = b.Id,
                PhotoURL = b.PhotoURl,
                Title = b.Title,
                PublishDate = b.PublishDate
            }).Take(3).ToList();
            return popularBlog;


        }
    }
}
