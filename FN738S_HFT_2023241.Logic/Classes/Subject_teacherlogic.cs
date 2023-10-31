using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Logic.Classes
{
    public class Subject_teacherlogic : ISubject_teacherlogic
    {
        private IRepository<Subject_teacher> repo;
        public Subject_teacherlogic(IRepository<Subject_teacher> repo)
        {
            this.repo = repo;
        }
        public void Create(Subject_teacher item)
        {
            if (item.Year_taught < 1500)
            {
                throw new ArgumentException("Year is too low.");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException($"Student not found with this id: {id}");
            }
            repo.Delete(id);
        }

        public Subject_teacher Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException($"Student not found with this id: {id}");
            }
            return item;
        }

        public IQueryable<Subject_teacher> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Subject_teacher item)
        {
            repo.Update(item);
        }
    }
}
