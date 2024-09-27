using EmployeeManagement.Models;

namespace EmployeeManagement
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }
}
