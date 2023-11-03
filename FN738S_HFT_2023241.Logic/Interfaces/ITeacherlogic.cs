using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Data;
using System.Collections.Generic;
using System.Linq;
using static FN738S_HFT_2023241.Models.Teacher;

namespace FN738S_HFT_2023241.Logic.Interfaces
{
    public interface ITeacherlogic
    {
        void Create(Teacher item);
        void Delete(int id);
        Teacher Read(int id);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher item);
        public IEnumerable<WhoIsAnAnimagus> GetAnimagus();
    }
}