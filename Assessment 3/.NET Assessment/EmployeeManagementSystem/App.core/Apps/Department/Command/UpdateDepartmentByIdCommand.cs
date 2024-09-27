using App.core.Apps.Employee.Command;
using App.core.Interface;
using App.core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.Apps.Department.Command
{
    /// <summary>
    /// Used To Update Department Data By Id and Return Boolean Value
    /// </summary>
    public class UpdateDepartmentByIdCommand : IRequest<bool>
    {
        public DepartmentDto Department { get; set; }
        public int Id { get; set; }
    }


    public class UpdateDepartmentByIdCommandHandler : IRequestHandler<UpdateDepartmentByIdCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public UpdateDepartmentByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<bool> Handle(UpdateDepartmentByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var department = await _appDbContext.Set<Domain.Department>().FindAsync(id);

            if (department == null)
            {
                return false;
            }

            department.DepartmentName = request.Department.DepartmentName;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }


}
