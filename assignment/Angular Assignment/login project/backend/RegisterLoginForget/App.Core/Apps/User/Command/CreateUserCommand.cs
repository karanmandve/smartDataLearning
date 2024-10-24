using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.User.Command
{
    public class CreateUserCommand : IRequest<bool>
    {
        public Domain.User User { get; set; }
    }


    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateUserCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.User;

            var userData = _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(us => us.Email == user.Email);

            if (userData != null)
            {
                return false;
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, 13);

            user.DateCreated = DateTime.Now;

            await _appDbContext.Set<Domain.User>().AddAsync(user);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

    }



}
