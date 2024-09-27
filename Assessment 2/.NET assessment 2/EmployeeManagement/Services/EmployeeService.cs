using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        static List<Employee> employees;
        static string[] designationList = ["Software Engineer", "Professor", "Lawyer", "Manager", "Accountant"];

        static EmployeeService()
        {
            // filePath

            employees = Enumerable.Range(0, 5).Select(index => new Employee
            {
                Id = index + 1,
                Name = $"Employee - {index + 1}",
                PhoneNumber = $"{index}6856876875",
                Email = $"employee{index+1}@gmail.com",
                Designation = designationList[index],

            })
            .ToList();
        }

        public List<Employee> GetEmployees() { 
            return employees;
        }


    }
}
