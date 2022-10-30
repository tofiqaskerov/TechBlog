﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
