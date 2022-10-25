using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Core.Entity.Models
{
    public class User : IdentityUser, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AboutAuthor { get; set; }
        public string  PhotoURL { get; set; }
        


    }
}
