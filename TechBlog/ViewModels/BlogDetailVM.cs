using Entities.Concrete;
using Entities.DTOs;

namespace TechBlog.ViewModels
{
    public class BlogDetailVM
    {
        public Blog Blog { get; set; } 
        public List<PopularBlogDTO>  PopularBlogs { get; set; }
        public Blog NextBlog { get; set; }
        public Blog PrevBlog { get; set; }
        public List<Category> Categories { get; set; }
        public List<Blog> RelatedBlogs { get; set; }

    }
}
