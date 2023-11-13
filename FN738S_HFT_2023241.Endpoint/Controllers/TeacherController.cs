using FN738S_HFT_2023241.Logic.Classes;
using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FN738S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacherlogic logic;

        public TeacherController(ITeacherlogic logic)
        {
            this.logic = logic;
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
        }

   
        [HttpPut("{id}")]
        public void Update([FromBody] Teacher value)
        {
            this.logic.Update(value);
        }

     
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Delete(id);
        }
    }
}
