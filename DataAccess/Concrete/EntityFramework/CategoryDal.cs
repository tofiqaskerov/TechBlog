using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CategoryDal : EfEntityRepositoryBase<Category, TechBlogDbContext>, ICategoryDal
    {
        public Category GetByName(string name)
        {
            using var _context = new TechBlogDbContext();
            var category = _context.Categories.FirstOrDefault(x => x.Name == name);
            return category;
        }
    }
}
