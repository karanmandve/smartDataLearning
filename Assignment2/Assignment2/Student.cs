using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Student
    {
        private int _id;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Id { get { return _id; } }

        public Student(int id, string firstName, string lastName)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;

        }

        // Displaying the full name if student
        public void DisplayFullName()
        {
            Console.WriteLine($"Teacher name is : {FirstName} {LastName}");
        }

    }
}
