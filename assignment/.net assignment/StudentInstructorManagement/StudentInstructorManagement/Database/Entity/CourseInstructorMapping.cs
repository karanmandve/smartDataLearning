using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInstructorManagement.Database.Entity
{
    public class CourseInstructorMapping
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        [ForeignKey(nameof(Instructor))]
        public int InstructorId { get; set; }

        // Navigation properties
        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
