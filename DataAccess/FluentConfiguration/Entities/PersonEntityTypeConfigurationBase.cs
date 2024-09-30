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
    public class PersonEntityTypeConfigurationBase : EntityTypeConfigurationBase<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.Ignore(x => x.Processes);
            //Definiendo conversion a string para el nivel de escolaridad
            builder.Property(x => x.Formation).HasConversion(c => c.ToString(), s => (School)Enum.Parse(typeof(School), s));
            
            //Definiendo relacion de la Person con sus Process
            //Relacion muchos a muchos con Operator
            builder.HasMany<Process>()
                .WithMany(p => p.Operators)
                //Creando tabla dinamica para relacionar Process con Operator
                .UsingEntity<Dictionary<string, object>>(
                    "Process Operators",
                    j => j.HasOne<Process>()
                        .WithMany(p => (IEnumerable<Dictionary<string, object>>)p.Operators) //chequear casteo cuando se haga la migracion
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Person>()
                        .WithMany()
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                );
            //Relacion muchos a muchos con Supervisor
            builder.HasMany<Process>()
                .WithMany(p => p.Supervisors)
                //Creando tabla dinamica para relacionar Process con Supervisor
                .UsingEntity<Dictionary<string, object>>(
                "Process Supervisors",
                j => j.HasOne<Process>()
                    .WithMany(p => (IEnumerable<Dictionary<string, object>>)p.Supervisors) //chquear tambien
                    .HasForeignKey("ProcessId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Person>()
                    .WithMany()
                    .HasForeignKey("SupervisorId")
                    .OnDelete(DeleteBehavior.Restrict)
                );
        }
    }
}
