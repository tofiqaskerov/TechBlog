using Entities.Concrete;
using Entities.DTOs;

namespace TechBlog.ViewModels
{
    public class BlogDetailVM
    {
        public Blog Blog { get; set; } 
        public List<PopularBlogDTO>  PopularBlogs { get; set; }

    }
}
