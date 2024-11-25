using core.Interface;
using domain.ModelDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.App.User.Command
{
    public class UpdateUserByIdCommand : IRequest<bool>
    {
        public UserDto User { get; set; }
        public int Id { get; set; }
    }



    public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public UpdateUserByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<bool> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var user = await _appDbContext.Set<domain.User>().FindAsync(id);

            if (user == null)
            {
                return false;
            }

            user.FirstName = request.User.FirstName;
            user.LastName = request.User.LastName;
            user.Email = request.User.Email;
            user.Role = request.User.Role;




            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
