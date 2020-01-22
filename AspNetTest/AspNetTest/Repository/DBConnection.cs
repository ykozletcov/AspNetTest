using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AspNetTest.Repository
{
    public class DBConnection
    {
        private IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Адрес БД
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Имя БазыДаных
        /// </summary>
        public string DataBase { get; set; }

        /// <summary>
        /// Порт БазыДаных
        /// </summary>
        public int Port { get; set; }
        public DBConnection()
        {
            DataBase = Configuration.GetSection("Connection:DataBase").Value;
            Port = Convert.ToInt32(Configuration.GetSection("Connection:Port").Value);
            Host = Configuration.GetSection("Connection:Host").Value;
            UserName = Configuration.GetSection("Connection:UserName").Value;
            Password = Configuration.GetSection("Connection:Password").Value;
        }

        /// <summary>
        /// получает строку подключения
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return String.Format("Server={0};Port={1};Database={2};User Id={3};Password={4}", Host, Port, DataBase,
                UserName, Password);
        }
    }
}
