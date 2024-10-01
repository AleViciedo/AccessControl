using AccessControl.Domain.Entities.ConfigurationData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.DataAccess.FluentConfiguration.Common;
using AccessControl.Domain;
using AccessControl.Domain.Common;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.DataAccess.FluentConfiguration.Persons
{
    public class PersonEntityTypeConfigurationBase : EntityTypeConfigurationBase<Domain.Entities.ConfigurationData.Person>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.ConfigurationData.Person> builder)
        {
            builder.ToTable("Persons");
            //builder.Ignore(x => x.Processes);
            //Definiendo conversion a string para el nivel de escolaridad
            builder.Property(x => x.Formation).HasConversion(c => c.ToString(), s => (School)Enum.Parse(typeof(School), s));
        }
    }
}
