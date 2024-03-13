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
                builder
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
                new Student(5, 4, "Padma Patil", false),
                new Student(6, 1, "Ginny Weasley", false),
                new Student(7, 2, "Blaise Zabini", true),
                new Student(8, 3, "Nymphadora Tonks", false), 
                new Student(9, 4, "Luna Lovegood", false),
                new Student(10, 1, "Ron Weasley", true),
                new Student(11, 1, "Neville Longbottom", false),
                new Student(12, 2, "Pansy Parkinson", false),
                new Student(13, 4, "Cho Chang", false),
                new Student(14, 3, "Ernie Macmillan", true),
                new Student(15, 4, "Michael Corner", true),
                new Student(16, 1, "Seamus Finnigan", true),
                new Student(17, 2, "Gregory Goyle", true),
                new Student(18, 2, "Vincent Crabbe", true),
                new Student(19, 3, "Hannah Abbott", false),
                new Student(20, 4, "Terry Boot", true)
            });
            modelBuilder.Entity<House>().HasData(new House[]
            {
                new House(1, "Gryffindor", "Godric Gryffindor", 350),
                new House(2, "Slytherin", "Salazar Slytherin", 240),
                new House(3, "Hufflepuff", "Helga Hufflepuff", 230),
                new House(4, "Ravenclaw", "Rowena Ravenclaw", 101)
            });
            modelBuilder.Entity<Teacher>(teacher => teacher
            .HasOne(teacher => teacher.House)
            .WithMany(house => house.Teachers)
            .HasForeignKey(teacher => teacher.House_Id)
            .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Teacher>().HasData(new Teacher[]
            {
                new Teacher(1, 2, "Severus Snape", false, false ),
                new Teacher(2, 3, "Silvanus Kettleburn", false, true),
                new Teacher(3, 4, "Dolores Umbridge", false, true),
                new Teacher(4, 1, "Elspeth MacGillony", true, false),
                new Teacher(5, 1, "Albus Dumbledore", false, false),
                new Teacher(6, 3,"Pomona Sprout", false, true),
                new Teacher(7, 1, "Remus Lupin", true, true),
                new Teacher(8, 2, "Horace Slughorn", false, true),
                new Teacher(9, 3, "Filius Flitwick", false, true),
                new Teacher(10, 4, "Sybill Trelawney", false, false),
                new Teacher(11, 1, "Minerva McGonagall", false, true),
                new Teacher(12, 3, "Charity Burbage", false, false),
                new Teacher(13, 4, "Gilderoy Lockhart", true, false),
                new Teacher(14, 1, "Mad-Eye Moody", true, true),
                new Teacher(15, 2, "Andromeda Tonks", false, true),
                new Teacher(16, 1, "Sirius Black", true, false),
                new Teacher(17, 3, "Rubeus Hagrid", true, true),
                new Teacher(18, 4, "Xenophilius Lovegood", false, false),
                new Teacher(19, 1, "James Potter", true, false),
                new Teacher(20, 2, "Lucius Malfoy", false, true)

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
                new Subject(5, "Herbology"),
                new Subject(6, "Transfiguration"),
                new Subject(7, "Charms"),
                new Subject(8, "Divination"),
                new Subject(9, "Ancient Runes"),
                new Subject(10, "Arithmancy"),
                new Subject(11, "History of Magic"),
                new Subject(12, "Astronomy"),
                new Subject(13, "Flying Lessons")

            });
            modelBuilder.Entity<Subject_teacher>().HasData(new Subject_teacher[]
           {
              new Subject_teacher(1, 1, 4, 1995),
              new Subject_teacher(2, 1, 1, 1996),
              new Subject_teacher(3, 5, 5, 1970),
              new Subject_teacher(4, 2, 3, 2000),
              new Subject_teacher(5, 6, 1, 2003),
              new Subject_teacher(6, 3, 1, 2000),
              new Subject_teacher(7, 4, 2, 1983),
              new Subject_teacher(8, 4, 1, 1988),
              new Subject_teacher(9, 11, 6, 1990),
              new Subject_teacher(10, 9, 7, 1991),
              new Subject_teacher(11, 17, 2, 1993),
              new Subject_teacher(12, 14, 11, 1994),
              new Subject_teacher(13, 10, 8, 1995),
              new Subject_teacher(14, 20, 4, 1996),
              new Subject_teacher(15, 15, 9, 1997),
              new Subject_teacher(16, 16, 12, 1998),
              new Subject_teacher(17, 19, 13, 1999)
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
