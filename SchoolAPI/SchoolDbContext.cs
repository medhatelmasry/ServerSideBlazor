using Microsoft.EntityFrameworkCore;
using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<Student>().HasData(
              new
              {
                  StudentId = Guid.NewGuid().ToString(),

                  FirstName = "Jane",
                  LastName = "Smith",
                  School = "Medicine"
              },
              new
              {
                  StudentId = Guid.NewGuid().ToString(),

                  FirstName = "John",
                  LastName = "Fisher",
                  School = "Engineering"
              },
              new
              {
                  StudentId = Guid.NewGuid().ToString(),

                  FirstName = "Pamela",
                  LastName = "Baker",
                  School = "Food Science"
              },
              new
              {
                  StudentId = Guid.NewGuid().ToString(),

                  FirstName = "Peter",
                  LastName = "Taylor",
                  School = "Mining"
              }
            );
        }
    }
}
