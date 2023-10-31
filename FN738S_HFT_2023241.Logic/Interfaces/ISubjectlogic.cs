using FN738S_HFT_2023241.Models;
using System.Linq;

namespace FN738S_HFT_2023241.Logic.Interfaces
{
    public interface ISubjectlogic
    {
        void Create(Subject item);
        void Delete(int id);
        Subject Read(int id);
        IQueryable<Subject> ReadAll();
        void Update(Subject item);
    }
}