using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class DbBlogContext : DbContext
    {
        public DbBlogContext() : base("DeflautConnection")
        {

        }

        public DbSet<Blog> blogs { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<User> users { get; set; }

    }
}