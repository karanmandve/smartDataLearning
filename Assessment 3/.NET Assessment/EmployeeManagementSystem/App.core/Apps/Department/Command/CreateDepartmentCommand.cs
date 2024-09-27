using App.core.Apps.Employee.Command;
using App.core.Interface;
using App.core.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.Apps.Department.Command
{
    /// <summary>
    /// Used To Add Department and Send Boolean Value
    /// </summary>
    public class CreateDepartmentCommand : IRequest<bool>
    {
        public DepartmentDto Department { get; set; }
    }


    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateDepartmentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = request.Department;

            var isDepartmentExist = _appDbContext.Set<Domain.Department>().FirstOrDefault(dept => dept.DepartmentName.ToLower() == department.DepartmentName.ToLower());

            if (isDepartmentExist != null) {
                return false;
            }

            var newDepartment = department.Adapt<Domain.Department>();

            await _appDbContext.Set<Domain.Department>().AddAsync(newDepartment);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

    }




}
