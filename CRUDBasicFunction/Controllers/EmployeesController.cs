using Microsoft.AspNetCore.Mvc;
using CRUDBasicFunction;
using Microsoft.AspNetCore.DataProtection;

namespace CRUDBasicFunction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static readonly List<Employees> employe = new List<Employees>
        {
            new Employees
            {
                Id = 1,
                FirstName="ferhan",
                LastName ="Abacı",
                Place =" Antalya"
            },
            new Employees
            {
                Id = 2,
                FirstName="Ahmet",
                LastName ="Ölmez",
                Place =" Ankara"
            }
        };

       [HttpGet]
       public async Task<ActionResult<List<Employees>>> Get()
        {
            return Ok(employe);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employees>> Get(int id)
        {
            var emp = employe.Find(h => h.Id == id);
            if (emp == null)
                return BadRequest("Employe is not found.");
            return Ok(employe);

        }

        [HttpPost]
        public async Task<ActionResult<List<Employees>>> AddEmploye(Employees emp)
        {
            employe.Add(emp);
            return Ok(employe);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employees>>> UpdateEmploye(Employees request)
        {
            var emp = employe.Find(h => h.Id == request.Id);
            if (emp == null)
                return BadRequest("Employe is not found");
            emp.FirstName = request.FirstName;
            emp.LastName = request.LastName;
            emp.Place =request.Place;
            return Ok(employe);

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Employees>>> DeleteEmploye(int id)
        {
            var emp = employe.Find(h => h.Id == id);
            if(emp == null)
                return BadRequest("Employe is not found");

            employe.Remove(emp);
            return Ok(employe);
        }

    }
}
