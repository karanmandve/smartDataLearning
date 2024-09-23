using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInstructorManagement.Database;
using StudentInstructorManagement.Database.Entity;

namespace StudentInstructorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorManagementController : ControllerBase
    {


        private readonly ApplicationDbContext dbContext;

        public InstructorManagementController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpGet]
        public IActionResult GetAllInstructors()
        {
            var allInstructor = dbContext.Instructors.ToList();
            return Ok(allInstructor);
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetInstructorsById(int id)
        {
            var instructor = dbContext.Instructors.Find(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(instructor);
        }


        [HttpPost]
        public IActionResult AddInstructor(Instructor instructor)
        {

            var instructorEntity = new Instructor()
            {
                InstructorName = instructor.InstructorName
            };

            dbContext.Instructors.Add(instructorEntity);
            dbContext.SaveChanges();

            return Ok(instructorEntity);

        }


        //[HttpPut]
        //[Route("{id:guid}")]
        //public IActionResult UpdateEmployeeById(Guid id, UpdateEmployeeDto updateEmployeeDto)
        //{
        //    var employee = dbContext.Employees.Find(id);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    employee.Name = updateEmployeeDto.Name;
        //    employee.Email = updateEmployeeDto.Email;
        //    employee.Phone = updateEmployeeDto.Phone;
        //    employee.salary = updateEmployeeDto.salary;

        //    dbContext.SaveChanges();

        //    return Ok(employee);
        //}



        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteInstructorById(int id)
        {
            var instructor = dbContext.Instructors.Find(id);

            if (instructor == null)
            {
                return NotFound();
            }

            dbContext.Instructors.Remove(instructor);
            dbContext.SaveChanges();

            return Ok("Instructor Deleted Successfully!!");
        }


    }
}
