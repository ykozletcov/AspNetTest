using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class UserRolesCollectionRow
    {
        public Guid RowID { get; set; }
        public int UserId { get; set; }
        public Guid RoleID { get; set; }

    }
}
