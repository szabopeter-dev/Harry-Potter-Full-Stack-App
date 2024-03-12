using FN738S_HFT_2023241.Endpoint.Services;
using FN738S_HFT_2023241.Logic.Classes;
using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;



namespace FN738S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentlogic logic;
        IHubContext<SignalRHub> hub;
        public StudentController(IStudentlogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Student> ReadAll()
        {
            return this.logic.ReadAll();
        }

      
        [HttpGet("{id}")]
        public Student Read(int id)
        {
            return this.logic.Read(id);
        }

      
        [HttpPost]
        public void Create([FromBody] Student value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("StudentCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Student value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("StudentUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var studentToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("StudentDeleted", studentToDelete);
        }
    }
}
