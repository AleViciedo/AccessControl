using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Domain;
using AccessControl.Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.DataAccess.FluentConfiguration.Entities
{
    public class SupervisorEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<Supervisor> builder)
        {
            builder.ToTable("Supervisors");
            builder.HasBaseType(typeof(Domain.Entities.ConfigurationData.Person));
            //builder.Ignore(x => x.Processes);
            builder.HasMany(x => x.Operators).WithOne(x => x.Supervisor).HasForeignKey(x => x.Supervisor);
            builder.HasMany(x => x.Processes)
                .WithMany(p => p.Supervisors)
                .UsingEntity<Dictionary<string, string>>(
                    "Process Supervisor",
                    j => j.HasOne<Domain.ValueObjects.Process>().WithMany().HasForeignKey("ProcessId"),
                    j => j.HasOne<Supervisor>().WithMany().HasForeignKey("SupervisorId")
                );
        }
    }
}
