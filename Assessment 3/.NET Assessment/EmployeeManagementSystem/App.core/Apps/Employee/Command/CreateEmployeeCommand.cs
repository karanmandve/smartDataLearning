using App.core.Interface;
using App.core.Models;
using Mapster;
using MediatR;

namespace App.core.Apps.Employee.Command
{
    /// <summary>
    /// Used To Create Employee and Send Boolean Value
    /// </summary>
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public EmployeeDto Employee { get; set; }
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
            var model = request.Employee;

            var department = await _appDbContext.Set<Domain.Department>().FindAsync(model.DepartmentId);

            if (department == null)
            {
                return false;
            }

            var employee = model.Adapt<Domain.Employee>();


            await _appDbContext.Set<Domain.Employee>().AddAsync(employee);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

    }



}
