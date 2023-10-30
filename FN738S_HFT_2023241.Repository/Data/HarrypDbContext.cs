using FN738S_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public DbSet <Room> Rooms { get; set; }
        public DbSet <TeacherHeadOfHouse> TeachersHeadOfHouse { get; set; }
        public DbSet <House> House { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hallgato\Source\Repos\FN738S_HFT_2023241\FN738S_HFT_2023241.Repository\Data\Harryp.mdf;Integrated Security=True";
                builder
                .UseSqlServer(conn);
            }
        }

    }
}
