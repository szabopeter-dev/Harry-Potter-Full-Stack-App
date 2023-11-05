using FN738S_HFT_2023241.Logic.Classes;
using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static FN738S_HFT_2023241.Models.House;
using static FN738S_HFT_2023241.Models.Student;
using static FN738S_HFT_2023241.Models.Subject;

namespace FN738S_HFT_2023241.Test
{
    [TestFixture]
    public class HouseTesterClass
    {
        Houselogic houselogic;
        Mock<IRepository<House>> mockHouseRepo;

        [SetUp]
        public void Init()
        {
            mockHouseRepo = new Mock<IRepository<House>>();
            mockHouseRepo.Setup(m => m.ReadAll()).Returns(new List<House>()
            {

                new House(){ID = 1, House_name = Models.Enums.HouseType.Gryffindor, Founder_name = "Godric Gryffindor", House_points = 100,
                Students = new List<Student>(){new Student() {Name = "Harry Potter"}, new Student() { Name = "Hermione Granger"} } },

                
                new House(){ID = 2, House_name = Models.Enums.HouseType.Hufflepuff, Founder_name = "Helga Hufflepuff", House_points = 110},
                new House(){ID = 3, House_name = Models.Enums.HouseType.Ravenclaw, Founder_name = "Rowena Ravenclaw", House_points = 120},



            }.AsQueryable());
            houselogic = new Houselogic(mockHouseRepo.Object);


        }

        [Test]
        public void GetStudentFromGryffindor()
        {
            var actual = houselogic.GetStudentFromGryffindor(Models.Enums.HouseType.Gryffindor);
            var expected = new List<WhoIsInGryffindor>()
            {
                new WhoIsInGryffindor() {studentname = "Harry Potter"},
                new WhoIsInGryffindor() {studentname = "Hermione Granger"}
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateHouseWithNotEnoughHousePoints()
        {
            // house_points > 100 - confirmed
            var lowhouse = new House() { House_points = 90 };
            try
            {houselogic.Create(lowhouse);}
            catch
            {}
            mockHouseRepo.Verify(m => m.Create(lowhouse), Times.Never);
        }
        [Test]
        public void CreateHouseWithEnoughHousePoints()
        {
            // house_points > 100 - confirmed
            var acceptedhouse = new House() { House_points = 101 };
            houselogic.Create(acceptedhouse);
            mockHouseRepo.Verify(m => m.Create(acceptedhouse), Times.Once);
        }
        [Test]
        public void ReadWithCorrectHouseId()
        {
            House house = new House()
            {
                ID = 100, House_name = Models.Enums.HouseType.Slytherin,
                House_points = 200, Founder_name= "Salazar Slytherin"
            };
            mockHouseRepo.Setup(m => m.Read(100)).Returns(house);
            var result = houselogic.Read(100);
            Assert.AreEqual(result, house);
        }
    }
    public class StudentTesterClass
    {
        Studentlogic studentlogic;
        Mock<IRepository<Student>> mockstudentRepository;

        [SetUp]
        public void Init()
        {
            mockstudentRepository = new Mock<IRepository<Student>>();
            mockstudentRepository.Setup(m => m.ReadAll()).Returns(new List<Student>()
            {
                new Student()
                { Id = 1, HouseId = 1,Name = "Harry Potter",Quidditch_player = true },
                 new Student()
                { Id = 2,HouseId = 2, Name = "Draco Melfoy",  Quidditch_player = true },
                  new Student()
                { Id = 3, HouseId = 3,Name = "Cedric Digory", Quidditch_player = true },
                   new Student()
                { Id = 4,HouseId = 4,Name = "Padma Patil", Quidditch_player = false}
            }.AsQueryable());

            studentlogic = new Studentlogic(mockstudentRepository.Object);
        }

        [Test]
        public void CreateStudentWithNotEnoughLengthName()
        {
            //name > 5 confirmed
            var shortnamedstudent = new Student() { Id = 5, HouseId = 4, Name = "Luna", Quidditch_player = false };
            try
            {
                studentlogic.Create(shortnamedstudent);
            }
            catch { }
            mockstudentRepository.Verify(m => m.Create(shortnamedstudent), Times.Never);
        }
       
        [Test]
        public void GetQuidditchPlayerStudents()
        {
            var actual = studentlogic.GetQuidditchPlayers();
            var expected = new List<WhoIsAQuidditchPlayer>()
            {
                new WhoIsAQuidditchPlayer() {studentname = "Harry Potter"},
                new WhoIsAQuidditchPlayer() {studentname = "Draco Melfoy"},
                new WhoIsAQuidditchPlayer() {studentname = "Cedric Digory"},
            };
            Assert.AreEqual(expected, actual);
        }

        
       
    }

    public class SubjectTesterClass
    {
        Subjectlogic subjectlogic;
        Mock<IRepository<Subject>> mockSubjectrepository;

        [SetUp]
        public void Init() 
        {
            mockSubjectrepository = new Mock<IRepository<Subject>>();
            mockSubjectrepository.Setup(m => m.ReadAll()).Returns(new List<Subject>()
            { 
                new Subject(){Id = 1, Subject_Name= "Potions", Teachers = 
                new List<Teacher>(){ new Teacher() { Id = 1, Name = "Silvanius Petigruw", House_Id = 1, Animagus= true }, 
                    new Teacher() {Id=2, Name="Jazminus Potter", House_Id= 2, Animagus = false }, 
                    new Teacher() {Id = 3, Name="Wizard Amalia", House_Id=2, Animagus=false} } },
                new Subject(){Id = 2, Subject_Name="Dark Arts"}
            }.AsQueryable());
            subjectlogic = new Subjectlogic(mockSubjectrepository.Object);
        }
        [Test]
        public void GetSubjectTeachers()
        {
            var actual = subjectlogic.GetTeacherFromSubject("Potions");
            var expected = new List<WhoTeachesTheSubject>()
            {
                new WhoTeachesTheSubject() {teachername = "Silvanius Petigruw", subjectname = "Potions"},
                new WhoTeachesTheSubject() {teachername = "Jazminus Potter", subjectname = "Potions"},
                new WhoTeachesTheSubject() {teachername = "Wizard Amalia", subjectname = "Potions"},
            };
            Assert.AreEqual(expected, actual);
        }
    }
}
