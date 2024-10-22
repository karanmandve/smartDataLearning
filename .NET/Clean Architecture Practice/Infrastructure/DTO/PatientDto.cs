using Domain.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public List<PatientAddressDto> patientAddresses { get; set; }
    }
}
