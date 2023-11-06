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
using static FN738S_HFT_2023241.Models.House;
using static FN738S_HFT_2023241.Models.Student;
using static FN738S_HFT_2023241.Models.Teacher;

namespace FN738S_HFT_2023241.Logic.Classes
{
    public class Teacherlogic : ITeacherlogic
    {
        private IRepository<Teacher> repo;
        public Teacherlogic(IRepository<Teacher> repo)
        {
            this.repo = repo;
        }
        public void Create(Teacher item)
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
                throw new ArgumentException($"Teacher not found with this id: {id}");
            }
            repo.Delete(id);
        }

        public Teacher Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException($"Teacher not found with this id: {id}");
            }
            return item;
        }

        public IQueryable<Teacher> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Teacher item)
        {
            repo.Update(item);
        }

        public IEnumerable<WhoIsAnAnimagus> GetAnimagus()
        {
            return ReadAll()
            .Where(teacher => teacher.Animagus)
            .Select(teacher => new WhoIsAnAnimagus
            {
                teachername = teacher.Name

            });
            
        }

        
    }
}

