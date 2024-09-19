namespace EmployeeAdminPortal.Models
{
    public class UpdateEmployeeDto
    {
        public required string Name { get; set; } // if not set nullable disable that property is required by default
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal salary { get; set; }
    }
}
