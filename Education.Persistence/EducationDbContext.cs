using Education.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Persistence
{
    public class EducationDbContext:DbContext
    {
        public EducationDbContext()
        {

        }
        public EducationDbContext(DbContextOptions<EducationDbContext> options):base(options)
        {

        }

        public DbSet<Curse> Curses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=localhost;Initial Catalog=EducationDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curse>()
                .Property(c => c.Price)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Curse>().HasData(
                new Curse
                {
                    CurseId = Guid.NewGuid(),
                    Description = "C# basic curse",
                    Title="C# From Zero to Hero",
                    CreationDate=DateTime.UtcNow,
                    PublishDate=DateTime.UtcNow.AddYears(2),
                    Price=60
                }
            );

            modelBuilder.Entity<Curse>().HasData(
               new Curse
               {
                   CurseId = Guid.NewGuid(),
                   Description = "Java Curse",
                   Title = "Mastery Java",
                   CreationDate = DateTime.UtcNow,
                   PublishDate = DateTime.UtcNow.AddYears(2),
                   Price = 40
               }
           );

            modelBuilder.Entity<Curse>().HasData(
               new Curse
               {
                   CurseId = Guid.NewGuid(),
                   Description = "Unit Test For Net Core",
                   Title = "NetCore Unit Testing",
                   CreationDate = DateTime.UtcNow,
                   PublishDate = DateTime.UtcNow.AddYears(2),
                   Price = 100
               }
           );
        }
    }
}
