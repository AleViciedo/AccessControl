using AccessControl.Domain.Common;
using AccessControl.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.DataAccess.FluentConfiguration.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.DataAccess.FluentConfiguration.ValueObjects
{
    public class ProcessAsEntityTypeConfiguration : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.HasKey(p => p.ProcessId);
            builder.ToTable("Processes");
            builder.Property(p => p.Name).IsRequired();
            builder.OwnsMany(p => p.Products, product =>
            {
                product.ToTable("Process Products");
                product.Property(p => p.Name).HasColumnName("Product Name").IsRequired();
                
            });

            
        }
    }
}
