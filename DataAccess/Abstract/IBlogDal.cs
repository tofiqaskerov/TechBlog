using Core.DataAccess;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntitieRepository<Blog>
    {
        List<Blog> GetAllBlogIncludeCategory();
        Blog GetBlogIncludeCategory(int id);
        List<Blog> GetLastThreeBlog();
        List<PopularBlogDTO> GetPopularBlogs();

        Blog GetNextBlog(int id);
        Blog GetPrevBlog(int id);
        List<Blog> GetRandomBlogs(int id);
    }
}
