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
    public class ContactManager : IContactService
    {
		private readonly IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

		public void AddAsync(Contact contact)
		{
			try
			{
				_contactDal.AddAsync(contact);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void Delete(Contact contact)
		{
			try
			{
				_contactDal.Delete(contact);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public List<Contact> GetAll()
        {
			try
			{
				return _contactDal.GetAll();
			}
			catch (Exception)
			{

				throw;
			}
        }

		public Contact GetById(int id)
		{
			try
			{
				return _contactDal.Get(x => x.Id == id);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
