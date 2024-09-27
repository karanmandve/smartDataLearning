using App.core.Apps.Employee.Query;
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

namespace App.core.Apps.Department.Query
{
    /// <summary>
    /// Used To Get All Department Data
    /// </summary>
    public class GetDepartmentQuery : IRequest<List<DepartmentDto>>
    {
    }


    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, List<DepartmentDto>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetDepartmentQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<DepartmentDto>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var allDepartment = await _appDbContext.Set<Domain.Department>().ToListAsync();

            return allDepartment.Adapt<List<DepartmentDto>>();
        }
    }




}
