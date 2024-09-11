using System;

namespace PracticeConsoleApp
{
    public static class StudentExtensions
    {
        public static int CalculateAge(this Student student)
        {
            return (DateTime.Today.Year - student.DateOfBirth.Year);
        }

        public static int CalculateAge(this Student student, DateTime dateTime)
        {
            Console.WriteLine(dateTime);
            return (DateTime.Today.Year - student.DateOfBirth.Year);
        }
    }
}
