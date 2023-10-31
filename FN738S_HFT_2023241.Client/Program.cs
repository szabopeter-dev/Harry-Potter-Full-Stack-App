using FN738S_HFT_2023241.Logic.Classes;
using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Data;
using FN738S_HFT_2023241.Repository.ModelRepositories;
using System;

namespace FN738S_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new HarrypDbContext();
            var repo = new StudentRepository(ctx);
            var logic = new Studentlogic(repo);

            

            var items = logic.ReadAll();
            ;
        }
    }
}
