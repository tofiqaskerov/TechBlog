using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class BlogCommentDal : EfEntityRepositoryBase<BlogComment, TechBlogDbContext>, IBlogCommentDal
    {
        public void AddAsync(BlogComment blogComment)
        {
            using var _context = new TechBlogDbContext();
            _context.Add(blogComment);
            _context.SaveChangesAsync();
        }
    }
}
