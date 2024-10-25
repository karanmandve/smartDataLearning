using App.Core.Interface;
using Domain.ModelDto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Agent.Query
{
    public class ValidateAgentQuery : IRequest<bool>
    {
        public LoginDto Login { get; set; }
    }

    public class ValidateAgentQueryHandler : IRequestHandler<ValidateAgentQuery, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public ValidateAgentQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(ValidateAgentQuery request, CancellationToken cancellationToken)
        {
            var agentDto = request.Login;

            var agent = await _appDbContext.Set<Domain.Agent>().FirstOrDefaultAsync(agent => agent.Email == agentDto.Email);

            if (agent == null || !BCrypt.Net.BCrypt.Verify(agentDto.Password, agent.Password))
            {
                return false;
            }

            return true;
        }

    }
}
