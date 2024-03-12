using FN738S_HFT_2023241.Endpoint.Services;
using FN738S_HFT_2023241.Logic.Classes;
using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FN738S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacherlogic logic;
        IHubContext<SignalRHub> hub;

        public TeacherController(ITeacherlogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Teacher> ReadAll()
        {
            return this.logic.ReadAll();
        }

    
        [HttpGet("{id}")]
        public Teacher Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Teacher value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("TeacherCreated", value);
        }

   
        [HttpPut]
        public void Update([FromBody] Teacher value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("TeacherUpdated", value);
        }

     
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teacherToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("TeacherDeleted", teacherToDelete);
        }
    }
}
