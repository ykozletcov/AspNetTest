using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AspNetTest.Repository;
using Microsoft.Extensions.Logging;
using SharedLibrary.Models;

namespace AspNetTest.Models
{
    public class FirstDataInitialize
    {
        private CryptographyHelper helper;

        public FirstDataInitialize()
        {
            helper = new CryptographyHelper();
        }
        public void Initialize()
        {
            var admn = CreateAdmn();
            var user = CreateDefaultUser();
            var roles = CreateRoles();

            using (ApplicationContext db = new ApplicationContext())
            {
                var admindb = db.Users.Where(x => x.ID == 0).FirstOrDefault();
                var userdb = db.Users.Where(x => x.ID == 0).FirstOrDefault();
                db.Roles.AddRange(roles);
                db.SaveChanges();
                var dbroles = db.Roles.ToList();
                if (admindb==null)
                {
                    var userrole = dbroles.Where(x => x.Name == "User").FirstOrDefault();
                    var adminrole = dbroles.Where(x => x.Name == "Admin").FirstOrDefault();
                    UserRoles userRoles = new UserRoles(user.ID,userrole.ID);
                    UserRoles admroles = new UserRoles(user.ID, adminrole.ID);
                    admn.UserRoles.Add(userRoles);
                    admn.UserRoles.Add(admroles);
                    db.Users.Add(admn);
                }
                if (userdb==null)
                {
                    var userrole = dbroles.Where(x => x.Name == "User").FirstOrDefault();
                    UserRoles userRoles = new UserRoles(user.ID, userrole.ID); 
                    user.UserRoles.Add(userRoles);
                    db.Users.Add(user);
                }
                db.SaveChanges();
            }
            
            
        }

        private List<Role> CreateRoles()
        {
            Role admin = new Role();
            admin.ID = Guid.NewGuid();
            admin.Name = "Admin";
            admin.Description = "Администратор";
            Role user = new Role();
            user.ID = Guid.NewGuid();
            user.Name = "User";
            user.Description = "Пользователь";
            List<Role> roles = new List<Role>();
            roles.Add(admin);
            roles.Add(user);
            return roles;
        }

        private User CreateAdmn()
        {
            User user = new User();
            user.ID = 0;
            user.Login = "admin";
            user.CreateDate = DateTime.Now;
            user.Email = "admin@admin.ru";
            user.ID = 0;
            user.Name = "admin";
            user.Password = helper.GetHashString("admin");
            return user;
        }
        private User CreateDefaultUser()
        {
            User user = new User();
            user.ID = 1;
            user.Login = "user";
            user.CreateDate = DateTime.Now;
            user.Email = "user@user.ru";
            user.ID = 0;
            user.Name = "User";
            user.Password = helper.GetHashString("user");
            return user;
        }
    }
}
