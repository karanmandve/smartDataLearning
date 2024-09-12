using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    public class Teacher
    {
        private int _id;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public Teacher(int id, string firstName, string lastName)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;

        }

        // Displaying the full name of teacher
        public void DisplayFullName()
        {
            Console.WriteLine($"Teacher name is : {FirstName} {LastName}");
        }

    }
}
