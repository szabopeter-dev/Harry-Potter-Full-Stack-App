using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Data;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.ComponentModel;

namespace FN738S_HFT_2023241.Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {


            HarrypDbContext db = new HarrypDbContext();

            foreach(var iteem in db.Subjects)
            {
                Console.WriteLine(iteem.Subject_Name);
                foreach (var teacher in iteem.Teachers)
                {
                    Console.WriteLine("\t" + teacher.Name);
                }
            }

            
            

            
        }

    }
}
