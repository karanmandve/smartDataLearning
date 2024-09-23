using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInstructorManagement.Database;
using StudentInstructorManagement.Database.Entity;

namespace StudentInstructorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorCourseController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;

        public InstructorCourseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpGet]
        public IActionResult GetInstructorCourseMapping()
        {
            var allInstructor = dbContext.CourseInstructors.ToList();
            return Ok(allInstructor);
        }


        [HttpPost]
        public IActionResult AddInstructorCourseMapping(CourseInstructorMapping courseInstructor)
        {

            var instructorEntity = new CourseInstructorMapping()
            {
                InstructorId = courseInstructor.InstructorId,
                CourseId = courseInstructor.CourseId,
            };

            dbContext.CourseInstructors.Add(instructorEntity);
            dbContext.SaveChanges();

            return Ok(instructorEntity);

        }


    }
}
