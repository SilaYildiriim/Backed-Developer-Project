using Backed_Developer_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed_Developer_Project.InfraStructure.EntityTypeConfiguration
{
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.ToTable("Forms");

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Description)
                .HasMaxLength(500);

            builder.Property(f => f.CreatedAt)
                .IsRequired();

            builder.Property(f => f.CreatedBy)
                .IsRequired();

            builder.HasOne(f => f.User)
                .WithMany(u => u.Forms)
                .HasForeignKey(f => f.UserId);

            builder.HasMany(f => f.FormFields)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
