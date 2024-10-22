using App.core.Interface;
using MediatR;

namespace App.core.Apps.Employee.Command
{
    /// <summary>
    /// Used To Delete Employee and Send Boolean Value
    /// </summary>
    public class DeleteEmployeeByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }


    public class DeleteEmployeeByIdCommandHandler : IRequestHandler<DeleteEmployeeByIdCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public DeleteEmployeeByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var student = await _appDbContext.Set<Domain.Employee>().FindAsync(id);

            if (student == null)
            {
                return false;
            }

            _appDbContext.Set<Domain.Employee>().Remove(student);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }




}
