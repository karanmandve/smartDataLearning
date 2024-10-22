using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    /// <summary>
    /// Getting and setting data of department
    /// </summary>
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public Department(int departmentId, string departmentName)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
        }

    }

    /// <summary>
    /// Getting and Setting data of employee
    /// </summary>
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }

        public Employee(int employeeId, string employeeName, int departmentId)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            DepartmentId = departmentId;
        }
    }
}
