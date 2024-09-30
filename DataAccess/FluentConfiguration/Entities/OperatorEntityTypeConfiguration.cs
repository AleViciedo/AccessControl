using AccessControl.Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.DataAccess.FluentConfiguration.Persons
{
    public class OperatorEntityTypeConfiguration : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.ToTable("Operators");
            builder.HasBaseType(typeof(Person));
            builder.Ignore(x => x.Processes);
            builder.HasOne(x => x.Supervisor).WithMany().HasForeignKey(x => x.Supervisor.CI);
        }
    }
}
