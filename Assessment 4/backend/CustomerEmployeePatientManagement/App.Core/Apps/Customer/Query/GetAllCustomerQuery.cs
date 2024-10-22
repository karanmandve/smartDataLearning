using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Customer.Query
{
    public class GetAllCustomer : IRequest<List<Domain.Customer>>
    {
    }

    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomer, List<Domain.Customer>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllCustomerHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Domain.Customer>> Handle(GetAllCustomer request, CancellationToken cancellationToken)
        {
            var allCustomer = await _appDbContext.Set<Domain.Customer>().ToListAsync();

            return allCustomer;
        }
    }
}





