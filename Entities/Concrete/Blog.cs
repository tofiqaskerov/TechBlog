using Core.Entity;
using Core.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{

    public class Blog : IEntity
    {
        public int Id { get; set; }
        public string PhotoURl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Hit { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public DateTime PublishDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string SeoURL { get; set; }

    }
}
