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
    public class GetEmployeeQuery : IRequest<List<Domain.Employee>>
    {
    }
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<Domain.Employee>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetEmployeeQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Domain.Employee>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var allEmployee = await _appDbContext.Set<Domain.Employee>().ToListAsync();

            return allEmployee;
        }
    }
}
