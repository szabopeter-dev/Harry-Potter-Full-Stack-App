using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Models.Enums;
using FN738S_HFT_2023241.Repository.Data;
using FN738S_HFT_2023241.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FN738S_HFT_2023241.Models.Student;
using static FN738S_HFT_2023241.Models.Subject;

namespace FN738S_HFT_2023241.Logic.Classes
{
    public class Studentlogic : IStudentlogic
    {
        private IRepository<Student> repo;

        public Studentlogic(IRepository<Student> repo)
        {
            this.repo = repo;
        }
        public void Create(Student item)
        {
            if (item.Name.Length < 5)
            {
                throw new ArgumentException("Name is too short.");
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

        public Student Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException($"Student not found with this id: {id}");
            }
            return item;
        }

        public IQueryable<Student> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Student item)
        {
            repo.Update(item);
        }
 
    }
}
