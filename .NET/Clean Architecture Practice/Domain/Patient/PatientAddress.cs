using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Patient
{
    public class PatientAddress
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public Patient Patient { get; set; }

    }
}
