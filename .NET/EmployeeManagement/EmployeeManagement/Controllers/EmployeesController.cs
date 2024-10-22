using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static List<Employee> employees;

        public EmployeesController(IEmployeeService service)
        {
            employees = service.GetEmployees();
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employees);
        }


        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            employees.Add(employee);

            return Created();
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee employee)
        {

            var obj = employees.FirstOrDefault(x => x.Id == id);

            if (obj == null)
                return NotFound();


            obj.Name = employee.Name;
            obj.PhoneNumber = employee.PhoneNumber;
            obj.Email = employee.Email;
            obj.Designation = employee.Designation;

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = employees.FirstOrDefault(x => x.Id == id);

            if (obj == null)
                return NotFound();

            employees.Remove(obj);

            return Ok();
        }
    }
}
