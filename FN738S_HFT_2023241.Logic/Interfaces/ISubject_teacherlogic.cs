using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Data;
using System.Collections.Generic;
using System.Linq;
using static FN738S_HFT_2023241.Models.Subject_teacher;

namespace FN738S_HFT_2023241.Logic.Interfaces
{
    public interface ISubject_teacherlogic
    {
        void Create(Subject_teacher item);
        void Delete(int id);
        Subject_teacher Read(int id);
        IQueryable<Subject_teacher> ReadAll();
        void Update(Subject_teacher item);
        
    }
}