using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Customer.Command
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public Domain.Customer Customer { get; set; }
    }


    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateCustomerCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = request.Customer;


            await _appDbContext.Set<Domain.Customer>().AddAsync(customer);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

    }

}

