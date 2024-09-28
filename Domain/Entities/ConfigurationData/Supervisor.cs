using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Domain.Common;

namespace AccessControl.Domain.Entities.ConfigurationData
{
    public class Supervisor : Person
    {
        List<Operator> Operators { get; set; }

        public Supervisor() : base()
        {
            Operators = new List<Operator>();
        }

        public Supervisor(string name, string cI, School? formation, Guid id) : base(name, cI, formation, id)
        {
            Operators = new List<Operator>();
        }

    }
}
