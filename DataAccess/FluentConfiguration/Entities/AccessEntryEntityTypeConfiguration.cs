using AccessControl.DataAccess.FluentConfiguration.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Domain;
using AccessControl.Domain.Entities.HistoricalData;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.DataAccess.FluentConfiguration.Entities
{
    public class AccessEntryEntityTypeConfiguration : EntityTypeConfigurationBase<AccessEntry>
    {
        public override void Configure(EntityTypeBuilder<AccessEntry> builder)
        {
            builder.ToTable("AccessEntries");
            base.Configure(builder);
            builder.Ignore(x => x.InBuilding);
            builder.HasOne(x => x.Person).WithMany().HasForeignKey(x => x.Person.Id);

        }
    }
}
