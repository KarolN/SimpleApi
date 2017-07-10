using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleApi.Controllers
{
    public class ValuesController : Controller
    {
        private static List<Employee> _employees;
        private static List<Office> _offices;
        private static int idCounter = 1;

        static ValuesController()
        {
            _offices = new List<Office>
            {
                new Office {Id = 0, Name = "Wroclaw"},
                new Office {Id = 1, Name = "Rzeszow"},
                new Office {Id = 2, Name = "Gdansk"}
            };
           _employees = new List<Employee>
           {
               new Employee{Hobby = "Programowanie", Id=0, Name="Jan", 
                   Surname = "Kowalski", OfficeId =  0, Pesel = "1234567", YearsInPgs = 5}
           };
        }
        // GET api/values
        [Route("api/offices")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_offices);
        }

        [Route("api/employees")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_employees);
        }
        
        [Route("api/employees")]
        [HttpPost]
        [SimpleAuthorize]
        public IActionResult Post([FromBody]Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            employee.Id = idCounter++;
            _employees.Add(employee);
            return StatusCode(201);
        }

        [Route("api/employees")]
        [HttpPut]
        [SimpleAuthorize]
        public IActionResult Put([FromBody]Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var oldEntity = _employees.Single(x => x.Id == employee.Id);
            _employees.Remove(oldEntity);
            _employees.Add(employee);
            return Ok();
        }

        [Route("api/employees")]
        [HttpDelete("{id}")]
        [SimpleAuthorize]
        public void Delete(int id)
        {
            var oldEntity = _employees.Single(x => x.Id == id);
            _employees.Remove(oldEntity);
        }
    }
}
