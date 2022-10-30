using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogCommentManager : IBlogCommentService
    {
		private readonly IBlogCommentDal _blogCommentDal;
		private readonly IBlogDal _blogDal;

		public BlogCommentManager(IBlogCommentDal blogCommentDal, IBlogDal blogDal)
		{
			_blogCommentDal = blogCommentDal;
			_blogDal = blogDal;
		}

		public void Add(BlogComment blogComment)
        {
			try
			{
                _blogCommentDal.AddAsync(blogComment);
			}
			catch (Exception)
			{

				throw;
			}
        }

		
	}
}
