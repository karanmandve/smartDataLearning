using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
