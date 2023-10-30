using FN738S_HFT_2023241.Repository.Data;
using System;

namespace FN738S_HFT_2023241.Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HarrypDbContext db = new HarrypDbContext();

            foreach (var item in db.Students)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
