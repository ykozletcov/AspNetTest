using System;
using System.Collections.Generic;
using SharedLibrary.Models;

namespace AspNetTest.ViewModels
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
