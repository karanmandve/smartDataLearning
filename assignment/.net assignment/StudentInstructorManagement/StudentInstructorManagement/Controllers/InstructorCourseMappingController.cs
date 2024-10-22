using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInstructorManagement.Database;
using StudentInstructorManagement.Database.Entity;

namespace StudentInstructorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorCourseMappingController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;

        public InstructorCourseMappingController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpGet]
        public IActionResult GetInstructorCourseMapping()
        {
            var allInstructorCourse = dbContext.CourseInstructors.ToList();
            return Ok(allInstructorCourse);
        }


        [HttpPost]
        public IActionResult AddInstructorCourseMapping(CourseInstructorMapping courseInstructor)
        {

            var instructorCourseEntity = new CourseInstructorMapping()
            {
                InstructorId = courseInstructor.InstructorId,
                CourseId = courseInstructor.CourseId,
                Course  = dbContext.Courses.Find(courseInstructor.CourseId),
                Instructor = dbContext.Instructors.Find(courseInstructor.InstructorId)
            };

            dbContext.CourseInstructors.Add(instructorCourseEntity);
            dbContext.SaveChanges();

            return Ok(instructorCourseEntity);

        }


    }
}
