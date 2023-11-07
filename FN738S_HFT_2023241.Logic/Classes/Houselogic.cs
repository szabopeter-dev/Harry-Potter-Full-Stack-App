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
using static FN738S_HFT_2023241.Models.Student;
using static FN738S_HFT_2023241.Models.Subject;

namespace FN738S_HFT_2023241.Logic.Classes
{
    public class Houselogic : IHouselogic
    {
        private IRepository<House> repo;
        private IEnumerable<House> houses;
        public Houselogic(IRepository<House> repo)
        {
            this.repo = repo;
        }
        public void Create(House item)
        {
            if(item.House_points < 100)
            {
                throw new ArgumentException("House Point is too low.");
            }
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



        public IEnumerable<WhoIsAQuidditchPlayerInTheHouse> GetQuidditchPlayers(HouseType name)
        {

            return ReadAll()
               .Where(_ => _.House_name.Equals(name))
               .SelectMany(_ => _.Students)
               .Where(_ => _.Quidditch_player.Equals(true))
               .Select(_ => new WhoIsAQuidditchPlayerInTheHouse()
               {
                   studentname = _.Name
               }) ;

        }

        //get retired housetyped teachers

       public IEnumerable<WhoIsARetiredTeacherOfHouse> GetRetiredTeachersFromHouse(HouseType name)
        {
            return ReadAll()
                .Where(_ => _.House_name.Equals(name))
                .SelectMany(_ => _.Teachers)
                .Where(_ => _.IsRetired.Equals(true))
                .Select(_ => new WhoIsARetiredTeacherOfHouse()
                {
                    teachername = _.Name
                });
        }
       


        public IEnumerable<WhoIsInGryffindor> GetStudentFromGryffindor(HouseType name)
        {

            return ReadAll()
                .Where(_ => _.House_name.Equals(name))
                .SelectMany(_ => _.Students)
            .Select(_ => new WhoIsInGryffindor()
            {
                studentname = _.Name
            });
        }

        
      
    }
}

