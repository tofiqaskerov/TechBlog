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
    public class ContactDal : EfEntityRepositoryBase<Contact, TechBlogDbContext>, IContactDal
    {
        public async void AddAsync(Contact contact)
        {
            using var _context = new TechBlogDbContext();
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }
    }
}
