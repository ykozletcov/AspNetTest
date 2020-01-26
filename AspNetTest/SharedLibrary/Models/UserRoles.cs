using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class UserRoles
    {
        public Guid RowID { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public UserRoles ()
        {
        }
        public UserRoles(int userId, Guid roleId)
        {
            RowID = Guid.NewGuid();
            UserId = userId;
            RoleId = roleId;
        }
    }
}
