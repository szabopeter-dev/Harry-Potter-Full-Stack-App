using FN738S_HFT_2023241.Models;
using System.Linq;

namespace FN738S_HFT_2023241.Logic.Interfaces
{
    public interface IStudentlogic
    {
        void Create(Student item);
        void Delete(int id);
        Student Read(int id);
        IQueryable<Student> ReadAll();
        void Update(Student item);
    }
}