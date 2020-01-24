using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetTest.Repository;

namespace AspNetTest.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
