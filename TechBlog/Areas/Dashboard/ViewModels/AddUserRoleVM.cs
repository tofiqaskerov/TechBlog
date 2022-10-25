using Core.Entity.Models;

namespace TechBlog.Areas.Dashboard.ViewModels
{
    public class AddUserRoleVM
    {
        public User User { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
