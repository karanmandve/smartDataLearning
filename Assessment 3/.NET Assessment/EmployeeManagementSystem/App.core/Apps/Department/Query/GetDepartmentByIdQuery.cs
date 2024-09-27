using App.core.Apps.Employee.Query;
using App.core.Interface;
using App.core.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.Apps.Department.Query
{
    /// <summary>
    /// Used To Get Department Data By Id and Return Boolean Value
    /// </summary>
    public class GetDepartmentByIdQuery : IRequest<DepartmentDto>
    {
        public int Id { get; set; }
    }


    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
    {

        private readonly IAppDbContext _appDbContext;

        public GetDepartmentByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _appDbContext.Set<Domain.Department>().FindAsync(request.Id);

            return department.Adapt<DepartmentDto>();
        }
    }



}
