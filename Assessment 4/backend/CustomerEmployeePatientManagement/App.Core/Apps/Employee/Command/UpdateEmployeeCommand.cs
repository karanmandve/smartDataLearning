using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Employee.Command
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public Domain.Employee Employee { get; set; }
        public int Id { get; set; }

    }


    public class UpdateEmployeeByIdCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public UpdateEmployeeByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var employee = await _appDbContext.Set<Domain.Employee>().FindAsync(id);

            if (employee == null)
            {
                return false;
            }

            employee.FirstName = request.Employee.FirstName;
            employee.LastName = request.Employee.LastName;
            employee.Age = request.Employee.Age;
            employee.Email = request.Employee.Email;
            employee.Gender = request.Employee.Gender;
            employee.JobTitle = request.Employee.JobTitle;
            employee.Department = request.Employee.Department;
            employee.Salary = request.Employee.Salary;
            employee.HireDate = request.Employee.HireDate;
            employee.Address = request.Employee.Address;
            employee.City = request.Employee.City;
            employee.State = request.Employee.State;
            employee.PostalCode = request.Employee.PostalCode;
            employee.Country = request.Employee.Country;
            employee.PhoneNumber = request.Employee.PhoneNumber;
            employee.StartDate = request.Employee.StartDate;
            employee.BenefitsPackage = request.Employee.BenefitsPackage;
            employee.VacationDays = request.Employee.VacationDays;
            employee.PerformanceRating = request.Employee.PerformanceRating;
            employee.IsEmployeeActive = request.Employee.IsEmployeeActive;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
