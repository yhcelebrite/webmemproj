using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace webmemdemo.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class userDbContext : DbContext
    {
        public userDbContext()
            : base("MySqlDemo")
        {
            this.Database.CreateIfNotExists();
        }
        public virtual DbSet<User> User { get; set; }
    }
}