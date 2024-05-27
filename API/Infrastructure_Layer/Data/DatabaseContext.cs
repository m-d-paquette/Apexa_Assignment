using Domain_Layer.Entities;
using Domain_Layer.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure_Layer.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Advisor> Advisors { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            // Ensure the db is created
            this.Database.EnsureCreated();

            if (!Advisors.Any())
            {
                // Add initial advisors
                Advisors.AddRange(new List<Advisor>(){
                    new Advisor
                    {
                        Id = 1,
                        Name = "John Smith",
                        SocialInsuranceNumber = "123123123",
                        HealthStatus = HealthStatus.Green
                    },
                    new Advisor
                    {
                        Id = 2,
                        Name = "Jane Doe",
                        SocialInsuranceNumber = "456456456",
                        HealthStatus = HealthStatus.Yellow
                    },
                    new Advisor
                    {
                        Id = 3,
                        Name = "Martha Stewart",
                        SocialInsuranceNumber = "789789789",
                        HealthStatus = HealthStatus.Red
                    }
                });
                this.SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AdvisorsDb");
        }
    }
}