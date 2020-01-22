using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetTest.Models;

namespace AspNetTest.Repository
{
    public class UserSqlRepository
    {
        public List<User> GetUsers()
        {
            var sqlQuery = "SELECT ID,Name,Login,Password FROM ~Users~ ORDER BY ID";
            WRKDataBase wrkDataBase;
            wrkDataBase = new WRKDataBase();
            List<User> ret = new List<User>();
            var rdr = wrkDataBase.CreateReader(sqlQuery);
            while (rdr.Read())
                ret.Add(new User(rdr));
            rdr.Close();
            wrkDataBase.Dispose();
            return ret;
        }
    }
}
