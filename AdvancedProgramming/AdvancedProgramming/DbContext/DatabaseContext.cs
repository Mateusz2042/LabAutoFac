using AdvancedProgramming.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AdvancedProgramming.Interfaces;

namespace AdvancedProgramming.DbContext
{
    public class DatabaseContext : System.Data.Entity.DbContext
    {
        public DatabaseContext() : base("Database")
        {
            Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
        }
        
        public DbSet<Kid> Kids { get; set; }
        public DbSet<Adult> Adults { get; set; }
    }
}
