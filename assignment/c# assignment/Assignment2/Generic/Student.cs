using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    /// <summary>
    /// this is a student class where we showing that data which is give my user.
    /// </summary>
    public class Student<T>
    {


        // define a variable of type T 
        public T Data;

        // define a constructor of the Student class which printing the type and the data
        public Student(T data)
        {
            Data = data;
            Console.WriteLine("Data passed: " + Data);
            Console.WriteLine("Type of Data: " + Data.GetType());
        }
    }
}
