using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Data;
using System.Collections.Generic;
using System.Linq;
using static FN738S_HFT_2023241.Models.Subject;

namespace FN738S_HFT_2023241.Logic.Interfaces
{
    public interface ISubjectlogic
    {
        void Create(Subject item);
        void Delete(int id);
        Subject Read(int id);
        IQueryable<Subject> ReadAll();
        void Update(Subject item);
        public IEnumerable<WhoTeachesTheSubject> GetTeacherFromSubject(string subjectname);
    }
}