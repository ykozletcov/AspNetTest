﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetTest.Controllers;
using AspNetTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedLibrary.Models;

namespace AspNetTest.Repository
{
    public enum UpdMode
    { 
        Name,
        Pwd
    }
    public class SqlRepository
    {
        private readonly ILogger _logger;

        public SqlRepository(ILogger logger)
        {
            _logger = logger;
        }

        public  List<User> GetUsers()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                     return  db.Users.ToList();
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error,e.Message);
                throw;
            }
        }

        public void CreateUser(User user)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
                throw;
            }
        }


        public int UpdateUser(int ID, UpdMode mode, string paramValue)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var user = db.Users.Where(x => x.ID == ID).First();
                    if (mode == UpdMode.Name)
                        user.Name = paramValue;
                    else
                        user.Password = paramValue;
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.ToString());
                throw;
            }
        }


        public int DeleteUser(int ID)
        {
            User user = GetUsers().Where(x => x.ID == ID).First();
            return DeleteUser(user);
        }

        public int DeleteUser(User user)
        {
            if (user == null)
                return -1;
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Users.Remove(user);
                    return db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.ToString());
                throw;
            }
        }

        public List<Role> GetUseRoles(int userID)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var UserRowCollection = db.UserRolesCollections.Where(x => x.UserId == userID).ToList();
                    List<Role> roles = new List<Role>(); 
                    foreach (var row in UserRowCollection)
                    {
                        var role = db.Roles.Where(x => x.ID == row.RoleID).FirstOrDefault();
                        if (role!=null)
                        {
                            roles.Add(role);
                        }
                    }

                    return roles;
                }
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.ToString());
                throw;
            }
        }
    }
}
