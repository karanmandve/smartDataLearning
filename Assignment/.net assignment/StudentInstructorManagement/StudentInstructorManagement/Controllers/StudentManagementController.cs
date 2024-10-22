using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInstructorManagement.Database;
using StudentInstructorManagement.Database.Entity;

namespace StudentInstructorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagementController : ControllerBase
    {


        private readonly ApplicationDbContext dbContext;

        public StudentManagementController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var allStudents = dbContext.Students.ToList();
            return Ok(allStudents);
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudentById(int id)
        {
            var student = dbContext.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        [HttpPost]
        public IActionResult AddStudent(Student student)
        {

            var studentEntity = new Student()
            {
                Name = student.Name,
                Email = student.Email,
            };

            dbContext.Students.Add(studentEntity);
            dbContext.SaveChanges();

            return Ok(studentEntity);

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
        public IActionResult DeleteStudentById(int id)
        {
            var student = dbContext.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();

            return Ok("Student Deleted Successfully!!");
        }



    }
}
