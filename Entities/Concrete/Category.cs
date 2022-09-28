using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category :IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "bos saxlama")]
        public string Name { get; set; }
    }
}
