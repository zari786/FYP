using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst.DLA
{
    public class DataInitilizer : DropCreateDatabaseIfModelChanges<DBContext>
    {
        public DataInitilizer()
        {
            this.Seed(new DBContext());
        }

        protected override void Seed(DBContext context)
        {
            base.Seed(context);
            UserAccount userAccount = new UserAccount()
            {
                Name = "Zaryab",
                Email = "zaryab@gmail.com",
                JobTitle = "student",
                Phone = "03406087204",
                CompanyName = "zaryab",
                Address = "My address",
                Country = "Pakistan"
            };
        }
    }
}