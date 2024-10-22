namespace EmployeeAdminPortal.Models
{
    public class AddEmployeeDto
    {
        public required string Name { get; set; } // if not set nullable disable that property is required by default
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal salary { get; set; }
    }
}
