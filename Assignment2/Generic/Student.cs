using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
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
