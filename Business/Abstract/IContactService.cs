using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        void AddAsync(Contact contact);
        void Delete(Contact contact);
        Contact GetById(int id);
        List<Contact> GetAll();
    }
}
