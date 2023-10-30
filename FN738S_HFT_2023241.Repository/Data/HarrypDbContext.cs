using FN738S_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Repository.Data
{
    public class HarrypDbContext : DbContext
    {
        public HarrypDbContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet <Student> Students { get; set; }
        public DbSet <Teacher> Teachers { get; set; }
        
        
        public DbSet <House> Houses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\handb\OneDrive\Desktop\feleveshft\FN738S_HFT_2023241.Repository\Data\HarryPotterDb.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                .UseSqlServer(conn)
                .UseLazyLoadingProxies();

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(student => student
            .HasOne(student => student.House)
            .WithMany(house => house.Students)
            .HasForeignKey(student => student.HouseId)
            .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student(1, 1, "Harry Potter"),
                new Student(2, 2, "Draco Malfoy")
            });
            modelBuilder.Entity<House>().HasData(new House[]
            {
                new House(1, Models.Enums.HouseType.Gryffindor, "Godric Gryffindor"),
                new House(2, Models.Enums.HouseType.Slytherin, "Salazar Slytherin")
            });
        }


    }
}
