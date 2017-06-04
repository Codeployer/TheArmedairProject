using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheArmedairProject.Models
{
    public class UsersModels
    {
        public int UserID { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public int PermID { get; set; }

        public virtual PermissionsModels Permissions { get; set; }
    }
}