using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI
{
    public class SchoolDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
    {
        public SchoolDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            var connStr = ConfigurationHelper.GetCurrentSettings("ConnectionStrings:DefaultConnection");
            optionsBuilder.UseSqlServer(connStr);
            return new SchoolDbContext(optionsBuilder.Options);
        }
    }
}
