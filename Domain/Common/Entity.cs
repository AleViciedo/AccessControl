using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Common
{
    abstract public class Entity
    {
        public Guid Id { get; set; }

        protected Entity() { }
        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
