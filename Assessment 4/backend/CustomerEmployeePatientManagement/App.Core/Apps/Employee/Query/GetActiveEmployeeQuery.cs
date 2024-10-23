using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Employee.Query
{
    public class GetActiveEmployeeQuery : IRequest<List<Domain.Employee>>
    {
    }

    public class GetActiveEmployeeQueryHandler : IRequestHandler<GetActiveEmployeeQuery, List<Domain.Employee>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetActiveEmployeeQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Domain.Employee>> Handle(GetActiveEmployeeQuery request, CancellationToken cancellationToken)
        {
            var allEmployee = await _appDbContext.Set<Domain.Employee>().Where(emp => emp.IsEmployeeActive == true).ToListAsync();

            return allEmployee;
        }
    }


}
