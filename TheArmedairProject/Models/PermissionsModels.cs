using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheArmedairProject.Models
{
    public class PermissionsModels
    {
        public int PermID { get; set; }
        public string PermName { get; set; }
        
        public virtual ICollection<UsersModels> Users { get; set; }
    }
}