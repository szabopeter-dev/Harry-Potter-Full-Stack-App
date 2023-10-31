using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Data;
using FN738S_HFT_2023241.Repository.GenericRepository;
using FN738S_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Repository.ModelRepositories
{
    public class HouseRepository : Repository<House>, IRepository<House>
    { 
        public HouseRepository(HarrypDbContext ctx) : base(ctx)
        { }
        public override House Read(int id)
        {
            return this.ctx.Houses.First(t => t.ID == id);
        }
        public override void Update(House item)
        {
            var old = Read(item.ID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }

    }
}
