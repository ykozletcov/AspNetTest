using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class ConnectionString
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string DataBase { get; set; }
        public int Port { get; set; }

        public ConnectionString(string userName, string password, string host, string dataBase, int port)
        {
            UserName = userName;
            Password = Password;
            Host = host;
            DataBase = dataBase;
            Port = port;
        }

        public ConnectionString()
        {

        }
        public string GetConnectionString()
        {
            return String.Format("Server={0};Port={1};Database={2};User Id={3};Password={4}",
                Host, Port, DataBase, UserName, Password);
        }
    }
}
