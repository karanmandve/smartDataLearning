using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInstructorManagement.Database;
using StudentInstructorManagement.Database.Entity;

namespace StudentInstructorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {


        private readonly ApplicationDbContext dbContext;

        public StudentCourseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpGet]
        public IActionResult GetStudentCourseMapping()
        {
            var allInstructor = dbContext.StudentCourses.ToList();
            return Ok(allInstructor);
        }


        [HttpPost]
        public IActionResult AddStudentCourseMapping(StudentCourseMapping studentCourse)
        {

            var instructorEntity = new StudentCourseMapping()
            {
                StudentId = studentCourse.Id,
                CourseId = studentCourse.CourseId,
            };

            dbContext.StudentCourses.Add(instructorEntity);
            dbContext.SaveChanges();

            return Ok(instructorEntity);

        }

    }
}
