using FN738S_HFT_2023241.Models;
using System.Linq;

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