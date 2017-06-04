using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheArmedairProject.Databases;

namespace TheArmedairProject.Models
{
    public class UsersModels
    {
        [Key]
        public int UserID { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public int PermID { get; set; }

        public virtual PermissionsModels Permissions { get; set; }
    }
}