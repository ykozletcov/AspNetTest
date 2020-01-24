﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetTest.Controllers;
using AspNetTest.Models;
using Microsoft.Extensions.Logging;

namespace AspNetTest.Repository
{
    public class SqlRepository
    {
        private readonly ILogger _logger;

        public SqlRepository(ILogger logger)
        {
            _logger = logger;
        }

        public List<User> GetUsers()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    return db.Users.ToList();
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error,e.Message);
                throw;
            }
        }
    }
}
