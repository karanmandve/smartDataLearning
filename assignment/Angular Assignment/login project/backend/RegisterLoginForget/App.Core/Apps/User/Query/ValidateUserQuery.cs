using App.Core.Interface;
using Domain.ModelDto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.User.Query
{
    public class ValidateUserQuery : IRequest<bool>
    {
        public LoginDto Login { get; set; }
    }

    public class ValidateUserQueryHandler : IRequestHandler<ValidateUserQuery, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public ValidateUserQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
        {
            var userDto = request.Login;

            var user = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(user => user.Email == userDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
            {
                return false;
            }

            return true;
        }

    }
}
