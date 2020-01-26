using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Models;

namespace AspNetTest.Models
{
    public  class ConfigLoader
    {
        public Config Config { get; set; }
        public ConfigLoader()
        {
            Config = new Config();
            Config.ConnectionString = new ConnectionString();
            Config.ConnectionString.DataBase = Configuration.GetSection("Connection:DataBase").Value;
            Config.ConnectionString.Port = Convert.ToInt32(Configuration.GetSection("Connection:Port").Value);
            Config.ConnectionString.Host = Configuration.GetSection("Connection:Host").Value;
            Config.ConnectionString.UserName = Configuration.GetSection("Connection:UserName").Value;
            Config.ConnectionString.Password = Configuration.GetSection("Connection:Password").Value;
        }
        private IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

       
    }
}
