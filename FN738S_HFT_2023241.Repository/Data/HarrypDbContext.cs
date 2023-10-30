using FN738S_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
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
        
        public DbSet <TeacherHeadOfHouse> TeachersHeadOfHouses { get; set; }
        public DbSet <House> Houses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\handb\OneDrive\Desktop\feleveshft\FN738S_HFT_2023241.Repository\Data\HarryPotterDatabase.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                //.UseSqlServer(conn)
                .UseInMemoryDatabase("HarryPotterDB")
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
                new Student(2, 2, "Draco Malfoy"),
                new Student(3, 1, "Hermione Granger"),
                new Student(4, 3, "Cedric Digorry"),
                new Student(5, 4, "Padma Patil")
            });
            modelBuilder.Entity<House>().HasData(new House[]
            {
                new House(1, Models.Enums.HouseType.Gryffindor, "Godric Gryffindor"),
                new House(2, Models.Enums.HouseType.Slytherin, "Salazar Slytherin"),
                new House(3, Models.Enums.HouseType.Hufflepuff, "Helga Hufflepuff"),
                new House(4, Models.Enums.HouseType.Ravenclaw, "Rowena Ravenclaw")
            });

            modelBuilder.Entity<Teacher>()
            .HasMany(x => x.Houses)
            .WithMany(x => x.Teachers)
            .UsingEntity<TeacherHeadOfHouse>(
            x => x.HasOne(x => x.House)
            .WithMany().HasForeignKey(x => x.House_ID).OnDelete(DeleteBehavior.Cascade),
            x => x.HasOne(x => x.Teacher)
            .WithMany().HasForeignKey(x => x.Teacher_ID).OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Teacher>().HasData(new Teacher[]
            {
                new Teacher(1, "Severus Snape", "Defense Against the Dark Arts"),
                new Teacher(2, "Silvanus Kettleburn", "Care of Magical Creatures"),
                new Teacher(3, "Dolores Umbridge", "Defense Against the Dark Arts"),
                new Teacher(4, "Elspeth MacGillony", "Study of Ancient Runes"),
                new Teacher(5, "Albus Dumbledore", "Transfiguration"),
                new Teacher(6, "Pomona Sprout", "Herbology")
            });
            modelBuilder.Entity<TeacherHeadOfHouse>().HasData(new TeacherHeadOfHouse[]
           {
                new TeacherHeadOfHouse(1,2, 1996),
                new TeacherHeadOfHouse(4, 1, 2010),
                new TeacherHeadOfHouse(5,1, 1997),
               
           });
            

        }


    }
}
