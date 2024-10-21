using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Patient.Command
{
    public class DeletePatientByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }



    public class DeletePatientByIdCommandHandler : IRequestHandler<DeletePatientByIdCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public DeletePatientByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeletePatientByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var patient = await _appDbContext.Set<Domain.Patient>().FindAsync(id);

            if (patient == null)
            {
                return false;
            }

            _appDbContext.Set<Domain.Patient>().Remove(patient);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }






}
