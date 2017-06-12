using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TheArmedairProject.Models;

namespace TheArmedairProject.Databases
{
    public class PostDB: DbContext
    {
        public DbSet<PostModels> PostsDB { get; set; }
    }
}