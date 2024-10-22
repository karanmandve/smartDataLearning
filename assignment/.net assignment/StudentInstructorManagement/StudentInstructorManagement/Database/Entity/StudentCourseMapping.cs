using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInstructorManagement.Database.Entity
{
    public class StudentCourseMapping
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
