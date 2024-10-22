using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Patient
{
    public class Patient : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public List<PatientAddress> patientAddresses { get; set; }

    }
}
