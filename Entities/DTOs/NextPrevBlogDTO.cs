using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class NextPrevBlogDTO
    {
        public int Id { get; set; }
        public string PhotoURl { get; set; }
        public string Title { get; set; }
    }
}
