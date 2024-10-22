using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Apps.Customer.Query
{
    public class GetActiveCustomerQuery : IRequest<List<Domain.Customer>>
    {
    }
    public class GetActiveCustomerQueryHandler : IRequestHandler<GetActiveCustomerQuery, List<Domain.Customer>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetActiveCustomerQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Domain.Customer>> Handle(GetActiveCustomerQuery request, CancellationToken cancellationToken)
        {
            var allCustomer = await _appDbContext.Set<Domain.Customer>().Where(cus => cus.IsCustomerActive == true).ToListAsync();

            return allCustomer;
        }
    }
}

