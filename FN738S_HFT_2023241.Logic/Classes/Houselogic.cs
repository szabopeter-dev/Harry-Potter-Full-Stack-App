using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN738S_HFT_2023241.Logic.Classes
{
    public class Houselogic : IHouselogic
    {
        private IRepository<House> repo;
        public Houselogic(IRepository<House> repo)
        {
            this.repo = repo;
        }
        public void Create(House item)
        {
            
            repo.Create(item);
        }

        public void Delete(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException($"House not found with this id: {id}");
            }
            repo.Delete(id);
        }

        public House Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException($"House not found with this id: {id}");
            }
            return item;
        }

        public IQueryable<House> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(House item)
        {
            repo.Update(item);
        }
    }
}

