using App.Core.Interface;
using Domain.ModelDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.User.Command
{
    public class ChangeUserPasswordCommand : IRequest<bool>
    {
        public ChangeUserPasswordDto UserPasswordDto { get; set; }
    }


    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        private readonly IAppDbContext _appDbContext;

        public ChangeUserPasswordCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var userPasswordDto = request.UserPasswordDto;

            var user = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(user => user.Email == userPasswordDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(userPasswordDto.OldPassword, user.Password))
            {
                return false;
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(userPasswordDto.NewPassword, 13);

            //_appDbContext.Set<Domain.User>().Update(user);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}
