using App.Core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Patient.Command
{
    public class UpdatePatientByIdCommand : IRequest<bool>
    {
        public Domain.Patient Patient { get; set; }
        public int Id { get; set; }
    }



    public class UpdatePatientByIdCommandHandler : IRequestHandler<UpdatePatientByIdCommand, bool>
    {

        private readonly IAppDbContext _appDbContext;

        public UpdatePatientByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<bool> Handle(UpdatePatientByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var patient = await _appDbContext.Set<Domain.Patient>().FindAsync(id);

            if (patient == null)
            {
                return false;
            }

            patient.FirstName = request.Patient.FirstName;
            patient.LastName = request.Patient.LastName;
            patient.Age = request.Patient.Age;
            patient.Gender = request.Patient.Gender;
            patient.Email = request.Patient.Email;
            patient.PhoneNumber = request.Patient.PhoneNumber;
            patient.Address = request.Patient.Address;
            patient.City = request.Patient.City;
            patient.State = request.Patient.State;
            patient.Country = request.Patient.Country;
            patient.PostalCode = request.Patient.PostalCode;
            patient.BloodType = request.Patient.BloodType;
            patient.Height = request.Patient.Height;
            patient.Weight = request.Patient.Weight;
            patient.Medications = request.Patient.Medications;
            patient.LastVisitDate = request.Patient.LastVisitDate;
            patient.NextAppointmentDate = request.Patient.NextAppointmentDate;
            patient.InsuranceProvider = request.Patient.InsuranceProvider;
            patient.InsurancePolicyNumber = request.Patient.InsurancePolicyNumber;



            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }





}
