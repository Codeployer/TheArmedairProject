using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheArmedairProject.Databases;

namespace TheArmedairProject.Models
{
    public class PermissionsModels
    {
        [Key]
        public int PermID { get; set; }
        public string PermName { get; set; }
        
        public virtual ICollection<UsersModels> Users { get; set; }
    }
}