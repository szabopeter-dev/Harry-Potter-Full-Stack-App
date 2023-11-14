using FN738S_HFT_2023241.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static FN738S_HFT_2023241.Models.House;
using System.Collections.Generic;
using static FN738S_HFT_2023241.Models.Subject;
using static FN738S_HFT_2023241.Models.Teacher;
using static FN738S_HFT_2023241.Models.Subject_teacher;



namespace FN738S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IHouselogic houselogic;
        ISubjectlogic subjectlogic;
        ISubject_teacherlogic subject_Teacherlogic;

        public StatController(IHouselogic houselogic, ISubjectlogic subjectlogic, ISubject_teacherlogic subject_Teacherlogic)
        {
            this.houselogic = houselogic;
            this.subjectlogic = subjectlogic;
            this.subject_Teacherlogic = subject_Teacherlogic;
        }

        [HttpGet("{name}")]
        public IEnumerable<WhoIsAQuidditchPlayerInTheHouse> GetQuidditchPlayers(string name)
        {
            return this.houselogic.GetQuidditchPlayers(name);
        }

        [HttpGet("{name}")]
        public IEnumerable<WhoIsARetiredTeacherOfHouse> GetRetiredTeachersFromHouse(string name)
        {
            return this.houselogic.GetRetiredTeachersFromHouse(name);
        }

        [HttpGet("{name}")]
        public IEnumerable<WhoIsInGryffindor> GetStudentFromGryffindor(string name)
        {
            return this.houselogic.GetStudentFromGryffindor(name);
        }

        [HttpGet("{subjectname}")]
        public IEnumerable<WhoTeachesTheSubject> GetTeacherFromSubject(string subjectname)
        {
            return this.subjectlogic.GetTeacherFromSubject(subjectname);
        }

        [HttpGet("{subjectname}")]
        public IEnumerable<WhoIsAnAnimagus> GetAnimagusTeachersFromASubjects(string subjectname)
        {
            return this.subjectlogic.GetAnimagusTeachersFromASubjects(subjectname);
        }
        [HttpGet("{year}")]
        public IEnumerable<WhoTaughtInThisYear> GetTeachersByYearTaught(int year)
        { 
            return this.subject_Teacherlogic.GetTeachersByYearTaught(year);
        }

    }
}
