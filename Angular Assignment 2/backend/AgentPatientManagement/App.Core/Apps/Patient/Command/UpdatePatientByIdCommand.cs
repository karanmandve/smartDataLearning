using App.Core.Interface;
using Domain;
using Domain.ModelDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Apps.Patient.Command
{
    public class UpdatePatientByIdCommand : IRequest<bool>
    {
        public PatientDto Patient { get; set; }
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

            patient.FirstName = patient.FirstName;
            patient.LastName = patient.LastName;
            patient.Age = patient.Age;
            patient.Gender = patient.Gender;
            patient.Email = patient.Email;
            patient.PhoneNumber = patient.PhoneNumber;
            patient.Address = patient.Address;
            patient.City = patient.City;
            patient.State = patient.State;
            patient.Country = patient.Country;
            patient.PostalCode = patient.PostalCode;
            patient.BloodType = patient.BloodType;
            patient.Medications = patient.Medications;
            patient.LastVisitDate = patient.LastVisitDate;
            patient.NextAppointmentDate = patient.NextAppointmentDate;
            patient.InsuranceProvider = patient.InsuranceProvider;
            patient.InsurancePolicyNumber = patient.InsurancePolicyNumber;
            patient.HasAgreeToTerms = patient.HasAgreeToTerms;
            patient.IsPatientActive = patient.IsPatientActive;



            await _appDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }





}
