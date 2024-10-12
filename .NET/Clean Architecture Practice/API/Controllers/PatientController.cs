using Infrastructure;
using Infrastructure.DTO;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly EhrDbContext _ehrDbContext;

        public PatientController(EhrDbContext ehrDbContext)
        {
            _ehrDbContext = ehrDbContext;
        }


        [HttpGet]
        public async Task<List<PatientDto>> GetAllPatient()
        {
            //return await _ehrDbContext.sp_GetAllPatient();

            // LAZY LOADING BUT NEED TO DO VIRTUAL AND ADD ONE PACKAGE (Microsoft.EntityFrameworkCore.Proxies) AND ADD IT IN SERVICES LIKE THIS (options.UseSqlServer("YourConnectionString").UseLazyLoadingProxies());)

            //var patient = await _ehrDbContext.Patients.FindAsync(1);
            //var patientAdderesses = patient.patientAddresses;
            //return patient.Adapt<PatientDto>();



            // USING EAGER LOADING BUT CYCLE DETECTED OFF

            var patients = await _ehrDbContext.Patients
                .Include(p => p.patientAddresses) // Eagerly load Appointments
                .Select(p => new PatientDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Active = p.Active,
                    CreatedDate = p.CreatedDate,
                    CreatedBy = p.CreatedBy,
                    patientAddresses = p.patientAddresses
                        .Select(a => a.Adapt<PatientAddressDto>()) // Use Adapt to convert to AppointmentDTO
                        .ToList()
                })
                .ToListAsync();




            // DIRECTLY CALL PROCEDURE LIKE THIS THIS NOT SUPPORT EAGER LOADING

            //var allPatient = await _ehrDbContext.Patients.FromSqlRaw("EXECUTE [dbo].[GetAllPatient]").ToListAsync();

            return patients.Adapt<List<PatientDto>>();



        }
    }
}
