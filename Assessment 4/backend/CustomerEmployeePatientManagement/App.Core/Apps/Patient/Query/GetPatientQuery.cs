using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Patient.Query
{
    public class GetPatientQuery : IRequest<List<Domain.Patient>>
    {
    }

    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, List<Domain.Patient>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetPatientQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Domain.Patient>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var allPatient = await _appDbContext.Set<Domain.Patient>().ToListAsync();

            return allPatient;
        }
    }



}
