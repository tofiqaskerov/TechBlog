using Core.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Keyless]
    public class User : IdentityUser, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }

    }
}
