using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Models.Enums;
using FN738S_HFT_2023241.Repository.Data;
using FN738S_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FN738S_HFT_2023241.Models.House;
using static FN738S_HFT_2023241.Models.Subject;
using static FN738S_HFT_2023241.Models.Teacher;

namespace FN738S_HFT_2023241.Logic.Classes
{
    public class Subjectlogic : ISubjectlogic
    {
        private IRepository<Subject> repo;
        public Subjectlogic(IRepository<Subject> repo)
        {
            this.repo = repo;
        }
        public void Create(Subject item)
        {
            if (item.Subject_Name.Length < 5)
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
                throw new ArgumentException($"Subject not found with this id: {id}");
            }
            repo.Delete(id);
        }

        public Subject Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException($"Subject not found with this id: {id}");
            }
            return item;
        }

        public IQueryable<Subject> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Subject item)
        {
            repo.Update(item);
        }

        

        

        public IEnumerable<WhoTeachesTheSubject> GetTeacherFromSubject(string subjectname)
        {

            return ReadAll()
                .Where(_ => _.Subject_Name.Equals(subjectname))
                .SelectMany(_ => _.Teachers)
            .Select(_ => new WhoTeachesTheSubject()
            {
                teachername = _.Name,
                subjectname = subjectname
                
                
                
                
            });
        }
        public IEnumerable<WhoIsAnAnimagus> GetAnimagusTeachersFromASubjects(string subjectname)
        {
            return ReadAll()
                .Where(_ => _.Subject_Name.Equals(subjectname))
            .SelectMany(_ => _.Teachers)
            .Where(_ => _.Animagus.Equals(true))
            .Select(_ => new WhoIsAnAnimagus()
            {
                teachername = _.Name,
                subjectname = subjectname
            });

        }
    }
}

