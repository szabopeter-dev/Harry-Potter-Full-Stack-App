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
    public class Subject_teacherRepository : Repository<Subject_teacher>, IRepository<Subject_teacher>
    {
        public Subject_teacherRepository(HarrypDbContext ctx) : base(ctx)
        { }
        public override Subject_teacher Read(int id)
        {
            return this.ctx.Subject_Teachers.First(t => t.Subject_teacher_id == id);
        }
        public override void Update(Subject_teacher item)
        {
            var old = Read(item.Subject_teacher_id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }

    }
}
