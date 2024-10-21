using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Customer.Query
{
    public class GetCustomerQuery : IRequest<List<Domain.Customer>>
    {
    }
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<Domain.Customer>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetCustomerQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Domain.Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var allCustomer = await _appDbContext.Set<Domain.Customer>().ToListAsync();

            return allCustomer;
        }
    }
}

