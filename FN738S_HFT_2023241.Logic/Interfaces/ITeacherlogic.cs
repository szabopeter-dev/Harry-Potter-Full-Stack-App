using FN738S_HFT_2023241.Models;
using System.Linq;

namespace FN738S_HFT_2023241.Logic.Interfaces
{
    public interface ITeacherlogic
    {
        void Create(Teacher item);
        void Delete(int id);
        Teacher Read(int id);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher item);
    }
}