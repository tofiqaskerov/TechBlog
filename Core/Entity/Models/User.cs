﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string AboutAuthor { get; set; }
        public string  PhotoURL { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }    

    }
}
