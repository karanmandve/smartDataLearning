using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInstructorManagement.Database;
using StudentInstructorManagement.Database.Entity;

namespace StudentInstructorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseMappingController : ControllerBase
    {


        private readonly ApplicationDbContext dbContext;

        public StudentCourseMappingController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpGet]
        public IActionResult GetStudentCourseMapping()
        {
            var allStudentCourses = dbContext.StudentCourses.ToList();

            //var allStudentCourses = dbContext.StudentCourses
            //    .Where(studentCourse => studentCourse.Course.CourseName == "mathematics")
            //    .Select(sc => new
            //    {
            //        StudentId = sc.Student.Id,
            //        StudentName = sc.Student.Name,
            //        CourseName = sc.Course.CourseName
            //    })
            //    .ToList();

            return Ok(allStudentCourses);

        }


        [HttpPost]
        public IActionResult AddStudentCourseMapping(StudentCourseMapping studentCourse)
        {

            var studentCourseEntity = new StudentCourseMapping()
            {
                StudentId = studentCourse.StudentId,
                CourseId = studentCourse.CourseId,
                Course = dbContext.Courses.Find(studentCourse.CourseId),
                Student = dbContext.Students.Find(studentCourse.StudentId),
            };

            dbContext.StudentCourses.Add(studentCourseEntity);
            dbContext.SaveChanges();

            return Ok(studentCourseEntity);

        }

    }
}
