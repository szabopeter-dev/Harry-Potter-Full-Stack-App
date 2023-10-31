using FN738S_HFT_2023241.Models;
using System.Linq;

namespace FN738S_HFT_2023241.Logic.Interfaces
{
    public interface IHouselogic
    {
        void Create(House item);
        void Delete(int id);
        House Read(int id);
        IQueryable<House> ReadAll();
        void Update(House item);
    }
}