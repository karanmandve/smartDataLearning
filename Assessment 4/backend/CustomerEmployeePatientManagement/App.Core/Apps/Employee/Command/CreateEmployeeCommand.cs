using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Employee.Command
{
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public Domain.Employee Employee { get; set; }
    }




    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateEmployeeCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = request.Employee;


            await _appDbContext.Set<Domain.Employee>().AddAsync(employee);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

    }



}
