using AccessControl.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.DataAccess.FluentConfiguration.Common
{
    abstract public class EntityTypeConfigurationBase<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure (EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
