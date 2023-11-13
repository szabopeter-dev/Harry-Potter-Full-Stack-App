using FN738S_HFT_2023241.Logic.Classes;
using FN738S_HFT_2023241.Logic.Interfaces;
using FN738S_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace FN738S_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentlogic logic;

        public StudentController(IStudentlogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Student value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
