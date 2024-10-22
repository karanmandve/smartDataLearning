using App.core.Interface;
using App.core.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.core.Apps.Employee.Query
{
    /// <summary>
    /// Getting All Employee By DepartmentId
    /// </summary>
    public class GetAllEmployeeByDeparmentId : IRequest<List<EmployeeDto>>
    {
        public int Id { get; set; }
    }


    public class GetAllEmployeeByDeparmentIdHandler : IRequestHandler<GetAllEmployeeByDeparmentId, List<EmployeeDto>>
    {

        private readonly IAppDbContext _appDbContext;

        public GetAllEmployeeByDeparmentIdHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<List<EmployeeDto>> Handle(GetAllEmployeeByDeparmentId request, CancellationToken cancellationToken)
        {
            var allEmployee = await _appDbContext.Set<Domain.Employee>().Where(emp => emp.DepartmentId == request.Id).ToListAsync();

            return allEmployee.Adapt<List<EmployeeDto>>();
        }
    }
}

