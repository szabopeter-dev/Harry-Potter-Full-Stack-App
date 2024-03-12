using FN738S_HFT_2023241.Endpoint.Services;
using FN738S_HFT_2023241.Logic.Classes;
using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FN738S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Subject_teacherController : ControllerBase
    {
        ISubject_teacherlogic logic;
        IHubContext<SignalRHub> hub;
        public Subject_teacherController(ISubject_teacherlogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Subject_teacher> ReadAll()
        {

            return this.logic.ReadAll();
        }

 
        [HttpGet("{id}")]
        public Subject_teacher Read(int id)
        {
            return this.logic.Read(id);
        }

  
        [HttpPost]
        public void Create([FromBody] Subject_teacher value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("Subject_teacherCreated", value);
        }

    
        [HttpPut]
        public void Update([FromBody] Subject_teacher value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("Subject_teacherUpdated", value);
        }

    
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var subjectTeacherToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("Subject_teacherDeleted", subjectTeacherToDelete);
        }
    }
}
