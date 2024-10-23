using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Patient
    {

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string BloodType { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Medications { get; set; }
        public DateTime LastVisitDate { get; set; }
        public DateTime NextAppointmentDate { get; set; }
        public string InsuranceProvider { get; set; }
        public int InsurancePolicyNumber { get; set; }

        public bool IsPatientActive { get; set; }
    }



}

