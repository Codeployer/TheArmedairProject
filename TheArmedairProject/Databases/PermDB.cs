using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheArmedairProject.Models;

namespace TheArmedairProject.Databases
{
    public class PermDB : DbContext
    {
        public DbSet<UsersModels> UsersDB { get; set; }
        public DbSet<PermissionsModels> PermissionsDB { get; set; }
    }
}