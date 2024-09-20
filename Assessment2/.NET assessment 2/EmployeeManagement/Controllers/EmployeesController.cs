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

        /// <summary>
        /// Use to get all the data
        /// </summary>
        /// <returns>return success if all data sended successfully</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employees);
        }

        /// <summary>
        /// Added data to the existing list
        /// </summary>
        /// <param name="employee">Taking Employee object</param>
        /// <returns>return success if created successfully otherwise return User alreay exist</returns>
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            var obj = employees.FirstOrDefault(x => x.Id == employee.Id);

            if (obj != null) {
                return Conflict("User already exists with the same ID");
            }

            employees.Add(employee);

            return Created();
        }


        /// <summary>
        /// Use to update the data
        /// </summary>
        /// <param name="id">Take Id in Url</param>
        /// <param name="employee">Take employee data or object in body</param>
        /// <returns>Return success if found otherwise return not found error</returns>
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

        /// <summary>
        /// Use for Deleting the employee
        /// </summary>
        /// <param name="id">Take Id as Url</param>
        /// <returns>Return success if deleted otherwise return not found.</returns>
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
