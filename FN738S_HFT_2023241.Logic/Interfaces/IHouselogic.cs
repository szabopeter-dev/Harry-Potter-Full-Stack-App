﻿using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using static FN738S_HFT_2023241.Models.House;

namespace FN738S_HFT_2023241.Logic.Interfaces
{
    public interface IHouselogic
    {
        void Create(House item);
        void Delete(int id);
        House Read(int id);
        IQueryable<House> ReadAll();
        void Update(House item);
        public IEnumerable<WhoIsInGryffindor> GetStudentFromGryffindor(HouseType name);
        public IEnumerable<WhoIsAQuidditchPlayerInTheHouse> GetQuidditchPlayers(HouseType name);
        public IEnumerable<WhoIsARetiredTeacherOfHouse> GetRetiredTeachersFromHouse(HouseType name);
    }
}