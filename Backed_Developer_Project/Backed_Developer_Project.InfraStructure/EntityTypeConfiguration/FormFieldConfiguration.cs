using Backed_Developer_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backed_Developer_Project.InfraStructure.EntityTypeConfiguration
{
    public class FormFieldConfiguration : IEntityTypeConfiguration<FormField>
    {
        public void Configure(EntityTypeBuilder<FormField> builder)
        {
            builder.ToTable("FormFields");

            builder.Property(ff => ff.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ff => ff.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ff => ff.Age)
                .IsRequired(false);
        }
    }
}
