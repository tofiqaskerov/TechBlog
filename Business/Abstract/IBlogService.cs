using Entities;
using Entities.Concrete;
using Entities.DTOs;
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
        void UpdateById(int id);
        void Delete(Blog blog);
        Blog Detail(int id);
        List<Blog> GetAll();
        Blog GetById(int id);
        List<Blog> GetByCategoryId(int id);
        List<Blog> GetByCategoryIdIncludeCategory(int id);
        Blog GetBlogIncludeCategory(int id);
        List<Blog> GetAllBlogIncludeCategory();
        List<Blog> GetLastThreeBlog();
        List<PopularBlogDTO> GetPopularBlogs();
        Blog GetNextBlog(int id);
        Blog GetPrevBlog(int id);
        List<Blog> GetRelatedBlogs(int id);
    }
}
