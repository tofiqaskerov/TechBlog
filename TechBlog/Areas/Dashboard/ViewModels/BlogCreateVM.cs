using Core.Entity.Models;
using Entities.Concrete;

namespace TechBlog.Areas.Dashboard.ViewModels
{
    public class BlogCreateVM
    {
        public List<Category> Categories { get; set; }
        public List<User> Users { get; set; }
    }
}
