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
        
        public DbSet <Subject> Subjects { get; set; }
        public DbSet <Subject_teacher> Subject_Teachers { get; set; }
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
                new Student(1, 1, "Harry Potter", true),
                new Student(2, 2, "Draco Malfoy", true),
                new Student(3, 1, "Hermione Granger", false),
                new Student(4, 3, "Cedric Digorry", false),
                new Student(5, 4, "Padma Patil", false)
            });
            modelBuilder.Entity<House>().HasData(new House[]
            {
                new House(1, Models.Enums.HouseType.Gryffindor, "Godric Gryffindor", 350),
                new House(2, Models.Enums.HouseType.Slytherin, "Salazar Slytherin", 240),
                new House(3, Models.Enums.HouseType.Hufflepuff, "Helga Hufflepuff", 230),
                new House(4, Models.Enums.HouseType.Ravenclaw, "Rowena Ravenclaw", 100)
            });
            modelBuilder.Entity<Teacher>(teacher => teacher
            .HasOne(teacher => teacher.House)
            .WithMany(house => house.Teachers)
            .HasForeignKey(teacher => teacher.House_Id)
            .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Teacher>().HasData(new Teacher[]
            {
                new Teacher(1, 2, "Severus Snape", false ),
                new Teacher(2, 3, "Silvanus Kettleburn", false),
                new Teacher(3, 4, "Dolores Umbridge", false),
                new Teacher(4, 1, "Elspeth MacGillony", true),
                new Teacher(5, 1, "Albus Dumbledore", false),
                new Teacher(6, 3,"Pomona Sprout", false),
                new Teacher(7, 1, "Remus Lupin", true)

            });
            modelBuilder.Entity<Subject>()
            .HasMany(x => x.Teachers)
            .WithMany(x => x.Subjects)
            .UsingEntity<Subject_teacher>(
            x => x.HasOne(x => x.Teacher)
            .WithMany().HasForeignKey(x => x.Teacher_ID).OnDelete(DeleteBehavior.Cascade),
            x => x.HasOne(x => x.Subject)
            .WithMany().HasForeignKey(x => x.Subject_ID).OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Subject>().HasData(new Subject[]
            {
                new Subject(1, "Defence Against the Dark Arts"),
                new Subject(2, "Care of Magical Creatures"),
                new Subject(3, "Muggle Studies"),
                new Subject(4, "Potions"),
                new Subject(5, "Herbology")

            });
            modelBuilder.Entity<Subject_teacher>().HasData(new Subject_teacher[]
           {
              new Subject_teacher(1, 1, 4, 1995),
              new Subject_teacher(2, 1, 1, 1996),
              new Subject_teacher(3, 5, 5, 1970),
              new Subject_teacher(4, 2, 3, 2000),
              new Subject_teacher(5, 6, 1, 2003),
              new Subject_teacher(6, 3, 1, 2000),
              new Subject_teacher(7, 4, 2, 1983)

           });
            modelBuilder.Entity<Subject_teacher>()
            .HasOne(r => r.Subject)
            .WithMany(subject => subject.Subject_Teachers)
            .HasForeignKey(r => r.Subject_ID)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Subject_teacher>()
            .HasOne(r => r.Teacher)
            .WithMany(teacher => teacher.Subject_Teachers)
            .HasForeignKey(r => r.Teacher_ID)
            .OnDelete(DeleteBehavior.Cascade);


        }


    }
}
