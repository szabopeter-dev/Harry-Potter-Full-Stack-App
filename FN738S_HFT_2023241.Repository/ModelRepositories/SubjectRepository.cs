using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Data;
using FN738S_HFT_2023241.Repository.GenericRepository;
using FN738S_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Repository.ModelRepositories
{
    public class SubjectRepository : Repository<Subject>, IRepository<Subject>
    {
        public SubjectRepository(HarrypDbContext ctx) : base(ctx)
        { }
        public override Subject Read(int id)
        {
            return this.ctx.Subjects.First(t => t.Id == id);
        }
        public override void Update(Subject item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }

    }
}
