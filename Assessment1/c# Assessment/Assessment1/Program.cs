using Assessment1;

public class Program
{
    private static void Main(string[] args)

    {
        // FIBONACCI SERIES

        var result = FibonacciSeries.Fibonacci(2);
        foreach (var num in result)
        {
            Console.WriteLine(num);
        }




        // SQAURE OF NUMBERS

        //var newList = new List<int>() { 1, 2, 3, 4, 5 };
        //Func<List<int>, List<int>> funcDelegate = SqureOfNumber.SqaureOfNumbers;
        //var resultList = funcDelegate(newList);
        //foreach (var num in resultList)
        //{
        //    Console.WriteLine(num);
        //}




        // MULTIPLE OF THREE

        //var newList = new List<int>() { 18, 1, 2, 3, 4, 5, 9, 15 };
        //var resultList = MultipleOfThree.MultipleOfThrees(newList);
        //foreach (var num in resultList)
        //{
        //    Console.WriteLine(num);
        //}





        // QUESTION NO 2

        var employeeList = new List<Employee>();
        string[] departmentArray = { "Finance", "HR", "IT", "Marketing", "Accounts" };
        int counter = 65;
        int counter2 = 0;

        // storing emplyee object by giving id, name and deparment_id
        for (int i = 0; i < 20; i++)
        {
            employeeList.Add(new Employee(i, ((char)counter).ToString(), counter2));
            counter2++;
            counter++;
            if (counter2 == 5)
            {
                counter2 = 0;
            }
        }

        var departmentList = new List<Department>();
        // storing department object by giving id and department_name
        for (int i = 0; i < 5; i++)
        {
            departmentList.Add(new Department(i, departmentArray[i]));
        }

        var resultList = EmployeeDetails(employeeList, departmentList);

        foreach (var str in resultList)
        {
            Console.WriteLine(str);
        }



    }



    /// <summary>
    /// Employee Details String Builder
    /// </summary>
    /// <param name="employees">Take list of employee object</param>
    /// <param name="departmentList">Take list of department object</param>
    /// <returns>Retrun list of string of details of employee</returns>
    public static List<string> EmployeeDetails(List<Employee> employees, List<Department> departmentList)
    {
        var resultList = new List<string>();
        foreach (var employee in employees)
        {
            resultList.Add($"Employee Id: {employee.EmployeeId}, Employee Name: {employee.EmployeeName}, Department Name: {departmentList[employee.DepartmentId].DepartmentName}");
        }

        return resultList;

    } 

}