using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CodeFirst.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeFirst.DLA
{
    public class DBContext : DbContext
    {
        public DBContext() : base("MyConString") { }
        
        public DbSet<Customer> userAccounts { get; set; }
        public DbSet<Services> services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<CodeFirst.Models.LoginModel> LoginModels { get; set; }

        public System.Data.Entity.DbSet<CodeFirst.Models.ResetPasswordModel> ResetPasswordModels { get; set; }
    }
}