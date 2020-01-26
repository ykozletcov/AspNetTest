using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class Role
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserRoles> UserRoles { get; set; }
        public Role()
        {
            UserRoles = new List<UserRoles>();
        }
    }
}
