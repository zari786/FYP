﻿using System;
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
        
        public DbSet<UserAccount> userAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}