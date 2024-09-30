using App.core.Interface;
using App.core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.Apps.Employee.Command
{
    /// <summary>
    /// Used To Update Employee and Send Boolean Value
    /// </summary>
    public class UpdateEmployeeByIdCommand : IRequest<bool>
    {
        public EmployeeDto Employee { get; set; }
        public int Id { get; set; }
    }


    public class UpdateEmployeeByIdCommandHandler : IRequestHandler<UpdateEmployeeByIdCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public UpdateEmployeeByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<bool> Handle(UpdateEmployeeByIdCommand request, CancellationToken cancellationToken)
        {

            var employee = await _appDbContext.Set<Domain.Employee>().FindAsync(request.Id);

            if (employee == null)
            {
                return false;
            }

            var department = await _appDbContext.Set<Domain.Department>().FindAsync(request.Employee.DepartmentId);

            if (department == null)
            {
                return false;
            }

            employee.EmployeeFirstName = request.Employee.EmployeeFirstName;
            employee.EmployeeLastName = request.Employee.EmployeeLastName;
            employee.Salary = request.Employee.Salary;
            employee.DepartmentId = request.Employee.DepartmentId;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }



}
