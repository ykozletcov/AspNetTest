﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class User : IdentityUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public List<UserRoles> UserRoles { get; set; }
        public User()
        {
            UserRoles = new List<UserRoles>();
        }
    }
}
