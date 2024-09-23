using Microsoft.EntityFrameworkCore;
using StudentInstructorManagement.Database.Entity;

namespace StudentInstructorManagement.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<StudentCourseMapping> StudentCourses { get; set; }
        public DbSet<CourseInstructorMapping> CourseInstructors { get; set; }

    }
}
