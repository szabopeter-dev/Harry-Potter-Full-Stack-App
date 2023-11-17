using FN738S_HFT_2023241.Logic.Classes;
using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using FN738S_HFT_2023241.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static FN738S_HFT_2023241.Models.House;
using static FN738S_HFT_2023241.Models.Student;
using static FN738S_HFT_2023241.Models.Subject;
using static FN738S_HFT_2023241.Models.Subject_teacher;
using static FN738S_HFT_2023241.Models.Teacher;

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
                //Gryffindor
                new House(){ID = 1, House_name = "Gryffindor", Founder_name = "Godric Gryffindor", House_points = 100,
                    Students = new List<Student>(){new Student() {Name = "Harry Potter", Quidditch_player = false}, new Student() { Name = "Hermione Granger", Quidditch_player = false} }, 
                    Teachers= new List<Teacher>(){ new Teacher() {Name = "Dolores Umbridge", Animagus = false, IsRetired = true },
                                                   new Teacher() { Name = "Elspeth Mqalagony", Animagus = true, IsRetired = false } } },

                //Hufflepuff
                new House(){ID = 2, House_name = "Hufflepuff", Founder_name = "Helga Hufflepuff", House_points = 110,
                Students = new List<Student>(){new Student() {Name = "Maximus Brutalismus", Quidditch_player = true}, new Student() { Name = "Crying Hernald", Quidditch_player = false}} },
                
                //Ravenclaw
                new House(){ID = 3, House_name = "Ravenclaw", Founder_name = "Rowena Ravenclaw", House_points = 120,
                Students = new List<Student>(){new Student() {Name = "Padma Patil", Quidditch_player = false}, new Student() { Name = "Marco Aquini", Quidditch_player = false} } },



            }.AsQueryable());
            houselogic = new Houselogic(mockHouseRepo.Object);


        }
        [Test]
        public void GetRetiredTeachersFromHouse()
        {
            var actual = houselogic.GetRetiredTeachersFromHouse("Gryffindor");
            var expected = new List<WhoIsARetiredTeacherOfHouse>()
            {
                new WhoIsARetiredTeacherOfHouse() {teachername = "Dolores Umbridge"}
            };
            Assert.AreEqual(expected, actual);
            
        }

        [Test]
        public void GetQuidditchPlayersFromTheHouse()
        {
            var actual = houselogic.GetQuidditchPlayers("Hufflepuff");
            var expected = new List<WhoIsAQuidditchPlayerInTheHouse>()
            { 
                new WhoIsAQuidditchPlayerInTheHouse() {studentname = "Maximus Brutalismus"}
            };
            Assert.AreEqual(expected, actual);
            
        }

        [Test]
        public void GetStudentFromHouse()
        {
            var actual = houselogic.GetStudentFromHouse("Gryffindor");
            var expected = new List<WhoIsInTheHouse>()
            {
                new WhoIsInTheHouse() {studentname = "Harry Potter"},
                new WhoIsInTheHouse() {studentname = "Hermione Granger"}
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
                ID = 100, House_name = "Slytherin",
                House_points = 200, Founder_name= "Salazar Slytherin"
            };
            mockHouseRepo.Setup(m => m.Read(100)).Returns(house);
            var result = houselogic.Read(100);
            Assert.AreEqual(result, house);
        }
    }
    [TestFixture]
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
       
       

        
       
    }
    [TestFixture]
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
                new List<Teacher>(){ new Teacher() { Id = 1, Name = "Silvanius Petigruw", House_Id = 1, Animagus= true},
                    new Teacher() {Id=2, Name="Jazminus Potter", House_Id= 2, Animagus = false }, 
                    new Teacher() {Id = 3, Name="Wizard Amalia", House_Id=2, Animagus=false} } },
                new Subject(){Id = 2, Subject_Name="Dark Arts"}
            }.AsQueryable());
            subjectlogic = new Subjectlogic(mockSubjectrepository.Object);
        }
        [Test]
        public void GetAnimagusTeacherFromASubject()
        {
            var actual = subjectlogic.GetAnimagusTeachersFromASubjects("Potions");
            var expected = new List<WhoIsAnAnimagus>()
            {
                new WhoIsAnAnimagus() {teachername = "Silvanius Petigruw", subjectname="Potions"}
            };
            Assert.AreEqual(expected, actual);
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
        [Test]
        public void CreateSubjectWithConfirmedName()
        {
            // subject_name > 5 - confirmed
            var acceptedsubject = new Subject() { Subject_Name = "Old Wizards" };
            subjectlogic.Create(acceptedsubject);
            mockSubjectrepository.Verify(m => m.Create(acceptedsubject), Times.Once);
        }
    }
    [TestFixture]
    public class TeacherTesterClass
    {
        Teacherlogic teacherlogic;
        Mock<IRepository<Teacher>> mockTeacherRepo;

        [SetUp]
        public void Init()
        {
            mockTeacherRepo = new Mock<IRepository<Teacher>>();
            mockTeacherRepo.Setup(m => m.ReadAll()).Returns(new List<Teacher>()
            { 
                new Teacher(){Id = 1,House_Id= 1,  Name = "Hagrid", Animagus = true },
                new Teacher(){Id = 2,House_Id= 2,  Name = "Percelus Piton", Animagus = false },
                new Teacher(){Id = 3,House_Id= 4,  Name = "Lupin Celsa", Animagus = true },
                new Teacher(){Id = 4,House_Id= 1,  Name = "Lomboton Jake", Animagus = false }

            }.AsQueryable());
            teacherlogic = new Teacherlogic(mockTeacherRepo.Object);
        }
       
    }
    [TestFixture]
    public class SubjectTeacherTester
    {
        Subject_teacherlogic subject_Teacherlogic;
        Mock<IRepository<Subject_teacher>> mockSubjectTeacherRepo;

        [SetUp]
        public void Init()
        {
            mockSubjectTeacherRepo = new Mock<IRepository<Subject_teacher>>();
            mockSubjectTeacherRepo.Setup(m => m.ReadAll()).Returns(new List<Subject_teacher>()
            {
                new Subject_teacher() {Subject_teacher_id = 1, Teacher_ID = 1, Subject_ID = 1, Year_taught = 2002},
                new Subject_teacher() {Subject_teacher_id = 2, Teacher_ID = 2, Subject_ID = 2, Year_taught = 2000},
                new Subject_teacher() {Subject_teacher_id = 3, Teacher_ID = 3, Subject_ID = 3, Year_taught = 1998},
                new Subject_teacher() {Subject_teacher_id = 4, Teacher_ID = 4, Subject_ID = 4, Year_taught = 2002},
            }.AsQueryable());
            subject_Teacherlogic = new Subject_teacherlogic(mockSubjectTeacherRepo.Object);
        }

        [Test]
        public void CreateSubject_teacherWithLowYearTaught()
        {
            //year taught > 1500 - confirmed
            var lowyeartaught = new Subject_teacher() { Subject_teacher_id = 40, Year_taught = 1333 };
            try
            {
                subject_Teacherlogic.Create(lowyeartaught);
            }
            catch 
            { 
            }
            mockSubjectTeacherRepo.Verify(m => m.Create(lowyeartaught), Times.Never);

        }
    }
}
