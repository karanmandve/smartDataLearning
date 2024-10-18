using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Employee.Command
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Id { get; set; }

    }




    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public DeleteEmployeeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var employee = await _appDbContext.Set<Domain.Employee>().FindAsync(id);

            if (employee == null)
            {
                return false;
            }

            _appDbContext.Set<Domain.Employee>().Remove(employee);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }





}
