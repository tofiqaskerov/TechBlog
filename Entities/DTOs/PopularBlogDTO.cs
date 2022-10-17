using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PopularBlogDTO
    {
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
