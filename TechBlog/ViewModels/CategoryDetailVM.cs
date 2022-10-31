using Entities.Concrete;
using Entities.DTOs;

namespace TechBlog.ViewModels
{
    public class CategoryDetailVM
    {
        public Category Category { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Category> Categories { get; set; }
        public List<PopularBlogDTO> PopularBlogs { get; set; }


    }
}
