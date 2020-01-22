using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetTest.Models;
using Npgsql;

namespace AspNetTest.Repository
{
    public class UserSqlRepository
    {
        public List<User> GetUsers()
        {
            var sqlQuery = "SELECT ID,Name,Login,Password FROM \"Users\"";
            DBConnection connection = new DBConnection();
            NpgsqlConnection conn = new NpgsqlConnection(connection.GetConnectionString());
            NpgsqlCommand comm = new NpgsqlCommand(sqlQuery, conn);
            List<User> ret = new List<User>();
            conn.Open(); //Открываем соединение.
            var reader = comm.ExecuteReader(); //Выполняем нашу команду.
            while (reader.Read())
                ret.Add(new User(reader));
            reader.Close();
            conn.Close(); //Закрываем соединение.
            return ret;
        }
    }
}
