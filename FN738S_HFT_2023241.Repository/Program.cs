using FN738S_HFT_2023241.Repository.Data;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace FN738S_HFT_2023241.Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {


            HarrypDbContext db = new HarrypDbContext();

            foreach (var item in db.Houses)
            {
                Console.WriteLine(item.House_name);
                foreach(var teacher in item.Teachers)
                {
                    Console.WriteLine("\t" + teacher.Name);
                }
            }
        }

    }
}
