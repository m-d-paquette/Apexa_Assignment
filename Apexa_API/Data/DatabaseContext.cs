using Apexa_API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Apexa_API.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AdvisorsDb");
        }
        public DbSet<Advisor> Advisors { get; set; }
    }
}