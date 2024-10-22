using App.core.Apps.Employee.Command;
using App.core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.Apps.Department.Command
{
    /// <summary>
    /// Used To Delete Department Data By Id and Return Boolean Value
    /// </summary>
    public class DeleteDepartmentByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }



    public class DeleteDepartmentByIdCommandHandler : IRequestHandler<DeleteDepartmentByIdCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public DeleteDepartmentByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteDepartmentByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var department = await _appDbContext.Set<Domain.Department>().FindAsync(id);

            if (department == null)
            {
                return false;
            }

            _appDbContext.Set<Domain.Department>().Remove(department);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }





}
