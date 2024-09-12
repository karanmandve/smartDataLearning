using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterface
{
    public record Customer(string Name, string Email, long PhoneNumber)
    {
        // Displaying the all data the data of customer
        public void Display()
        {
            Console.WriteLine($"Name : {Name}, Email : {Email}, Phone Number : {PhoneNumber}");
        }
    }

    public record Employee (int EmployeeId, int EmployeeAge, string EmployeeName, string EmployeeEmail, long EmployeePhoneNumber)
    {
        // Displaying the all data the employee
        public void Display()
        {
            Console.WriteLine($"Name : {EmployeeName}, Age {EmployeeAge}, Email : {EmployeeEmail}, Phone Number : {EmployeePhoneNumber}");
        }
    }

}
