using FN738S_HFT_2023241.Models;
using System;

namespace FN738S_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:3736/", "Hogwarts");

            ////testing logics linq non crud methods in main
            //var ctx = new HarrypDbContext();

            //var studentrepo = new StudentRepository(ctx);
            //var logic = new Studentlogic(studentrepo);

            //var teacherrepo = new TeacherRepository(ctx);
            //var teacherlogic = new Teacherlogic(teacherrepo);


            //var houserepo = new HouseRepository(ctx);
            //var houselogic = new Houselogic(houserepo);

            //var subjectrepo = new SubjectRepository(ctx);
            //var subjectlogic = new Subjectlogic(subjectrepo);

            //var subject_teacherrepo = new Subject_teacherRepository(ctx);
            //var subject_teacherlogic = new Subject_teacherlogic(subject_teacherrepo);


            //var nc1 = houselogic.GetStudentFromGryffindor(Models.Enums.HouseType.Gryffindor);

            //var nc2 = subject_teacherlogic.GetTeachersByYearTaught(2000);

            //var nc3 = subjectlogic.GetTeacherFromSubject("Defence Against the Dark Arts");

            //var nc4 = houselogic.GetQuidditchPlayers(Models.Enums.HouseType.Slytherin);

            //var nc5 = subjectlogic.GetAnimagusTeachersFromASubjects("Defence Against the Dark Arts");

            //var nc6 = houselogic.GetRetiredTeachersFromHouse(Models.Enums.HouseType.Gryffindor);

            

        }
    }
}
