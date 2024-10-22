using Domain.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class PatientAddressConfiguration : IEntityTypeConfiguration<PatientAddress>
    {
        public void Configure(EntityTypeBuilder<PatientAddress> builder)
        {
            builder.ToTable("PatientAddress");

            builder.HasKey(pa => pa.Id);
            builder.Property(pa => pa.AddressLine1).IsRequired().HasMaxLength(300);

            builder.HasOne(pa => pa.Patient)
                .WithMany(pa => pa.patientAddresses)
                .HasForeignKey(pa => pa.PatientId)
                .IsRequired();

        }
    }
}
