using System;
using System.Collections.Generic;

namespace AspNetTest.Models
{
    public class HomeViewModel
    {
        public List<User> Users { get; set; }

        public User User { get; set; }

        public HomeViewModel()
        {
            User = new User();
            Users = new List<User>();
        }
    }
}
