using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Customer.Command
{
    public class DeleteCustomerByIdPermanentCommand : IRequest<bool>
    {

        public int Id { get; set; }
    }



    public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdPermanentCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public DeleteCustomerByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteCustomerByIdPermanentCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var customer = await _appDbContext.Set<Domain.Customer>().FindAsync(id);

            if (customer == null)
            {
                return false;
            }

            _appDbContext.Set<Domain.Customer>().Remove(customer);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }


}

