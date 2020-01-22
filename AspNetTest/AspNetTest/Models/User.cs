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

        public User(IDataRecord rec)
        {
            if (rec["ID"] != null) { ID = Convert.ToInt32(rec["ID"]); };
            if (rec["Name"] != null) { Name = rec["Name"].ToString(); };
            if (rec["Login"] != null) { Login = rec["Login"].ToString(); };
            if (rec["Password"] != null) { Password = rec["Password"].ToString(); };
        }

        public User(int id, string name, string login, string password)
        {
            ID = id;
            Name = name;
            Login = login;
            Password = password;
        }

       
    }
}
