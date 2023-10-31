using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Data;
using FN738S_HFT_2023241.Repository.Interfaces;
using FN738S_HFT_2023241.Repository.ModelRepositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.ComponentModel;
using System.Linq;

namespace FN738S_HFT_2023241.Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {


            HarrypDbContext db = new HarrypDbContext();

            //test off relations working
            //foreach (var iteem in db.Subjects)
            //{
            //    Console.WriteLine(iteem.Subject_Name);
            //    foreach (var subject_teacher in iteem.Subject_Teachers)
            //    {
            //        Console.WriteLine("\t" + subject_teacher.Year_taught + ": " + subject_teacher.Teacher.Name);
            //    }
            //}

            //test of Irepository
            //IRepository<House> repo = new HouseRepository(new HarrypDbContext());

            //var items = repo.ReadAll().ToArray();


        }

    }
}
