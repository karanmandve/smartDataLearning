using App.core.Interface;
using App.core.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.Apps.Employee.Query
{
    /// <summary>
    /// Used To Get All Employee and Send Data Value
    /// </summary>
    public class GetEmployeeQuery : IRequest<List<EmployeeDto>>
    {
    }


    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<EmployeeDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetEmployeeQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var list = await _appDbContext.Set<Domain.Employee>().ToListAsync();

            return list.Adapt<List<EmployeeDto>>();
        }
    }



}
