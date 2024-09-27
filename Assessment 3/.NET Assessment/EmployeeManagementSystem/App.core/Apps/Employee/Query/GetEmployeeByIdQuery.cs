using App.core.Interface;
using App.core.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.Apps.Employee.Query
{
    /// <summary>
    /// Used To Get Employee By Id and Send Data Value
    /// </summary>
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }


    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {

        private readonly IAppDbContext _appDbContext;

        public GetEmployeeByIdQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _appDbContext.Set<Domain.Employee>().FindAsync(request.Id);
            return employee.Adapt<EmployeeDto>();
        }
    }



}
