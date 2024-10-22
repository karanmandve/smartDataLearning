using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInstructorManagement.Database;
using StudentInstructorManagement.Database.Entity;

namespace StudentInstructorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseManagementController : ControllerBase
    {


        private readonly ApplicationDbContext dbContext;

        public CourseManagementController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var allCourses = dbContext.Courses.ToList();
            return Ok(allCourses);
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCoursesById(int id)
        {
            var course = dbContext.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }


        [HttpPost]
        public IActionResult AddCourse(Course course)
        {

            var courseEntity = new Course()
            {
                CourseName = course.CourseName
            };

            dbContext.Courses.Add(courseEntity);
            dbContext.SaveChanges();

            return Ok(courseEntity);

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
        public IActionResult DeleteCourseById(int id)
        {
            var course = dbContext.Courses.Find(id);

            if (course == null)
            {
                return NotFound();
            }

            dbContext.Courses.Remove(course);
            dbContext.SaveChanges();

            return Ok("Course Deleted Successfully!!");
        }



    }
}
