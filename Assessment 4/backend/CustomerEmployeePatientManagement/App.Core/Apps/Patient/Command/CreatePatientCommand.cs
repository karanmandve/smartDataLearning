using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Patient.Command
{



    public class CreatePatientCommand : IRequest<bool>
    {
        public Domain.Customer Customer { get; set; }
    }


    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, bool>
    {
        private readonly IAppDbContext _appDbContext;

        public CreatePatientCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var customer = request.Customer;


            await _appDbContext.Set<Domain.Customer>().AddAsync(customer);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

    }




}

