using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            try
            {
                blog.SeoURL = "test";
                blog.PublishDate = DateTime.Now;
                blog.UpdateDate = DateTime.Now;
                _blogDal.Add(blog);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Blog blog)
        {
            try
            {
                _blogDal.Delete(blog);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Blog Detail(int id)
        {
            try
            {
                var blog = _blogDal.GetBlogIncludeCategory(id);
                blog.Hit += 1;
                _blogDal.Update(blog);
                return blog;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public List<Blog> GetAll()
        {
           return _blogDal.GetAll();    
        }

        public List<Blog> GetAllBlogIncludeCategory()
        {
            try
            {
                return _blogDal.GetAllBlogIncludeCategory();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Blog GetBlogIncludeCategory(int id)
        {
            try
            {
                var blog = _blogDal.GetBlogIncludeCategory(id);
                return blog;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Blog GetById(int id)
        {
            try
            {

                var blog = _blogDal.Get(x => x.Id == id);
              
                _blogDal.Update(blog);
                return blog;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Blog> GetLastThreeBlog()
        {
            try
            {
                return _blogDal.GetLastThreeBlog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<NextPrevBlogDTO> GetNextPrevBlog(int id)
        {
            throw new NotImplementedException();
        }

        public List<PopularBlogDTO> GetPopularBlogs()
        {
            try
            {
                return _blogDal.GetPopularBlogs();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Blog blog)
        {
            try
            {
                var oldBlog = _blogDal.Get(x =>x.Id == blog.Id);
                blog.UpdateDate = DateTime.Now;
                blog.PublishDate = oldBlog.PublishDate;
                blog.Hit = oldBlog.Hit;
                blog.SeoURL = "test";
                _blogDal.Update(blog);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
