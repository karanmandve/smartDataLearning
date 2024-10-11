
using Domain.Patient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class EhrDbContext : DbContext
    {
        public EhrDbContext(DbContextOptions<EhrDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientAddress> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
