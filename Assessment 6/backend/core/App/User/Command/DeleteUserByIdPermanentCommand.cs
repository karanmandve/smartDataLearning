using core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.App.User.Command
{
    public class DeleteUserByIdPermanentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }



    public class DeleteUserByIdPermanentCommandHandler : IRequestHandler<DeleteUserByIdPermanentCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public DeleteUserByIdPermanentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteUserByIdPermanentCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var user = await _appDbContext.Set<domain.User>().FindAsync(id);

            if (user == null)
            {
                return false;
            }

            _appDbContext.Set<domain.User>().Remove(user);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
