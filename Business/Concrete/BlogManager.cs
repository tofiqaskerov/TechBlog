using Business.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        public void Add(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void Delete(int blogId)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            throw new NotImplementedException();
        }

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
