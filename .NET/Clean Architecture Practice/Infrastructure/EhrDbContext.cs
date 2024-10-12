
using Domain.Patient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

namespace Infrastructure
{
    public class EhrDbContext : DbContext
    {
        public EhrDbContext(DbContextOptions<EhrDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientAddress> Addresses { get; set; }

        public async Task<List<Patient>> sp_GetAllPatient()
        {
            return await Patients.FromSqlRaw("EXECUTE [dbo].[GetAllPatient]").ToListAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
