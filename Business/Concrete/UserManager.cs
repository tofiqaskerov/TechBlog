using Business.Abstract;
using Core.Entity.Models;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly TechBlogDbContext _context;

        public UserManager(TechBlogDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
