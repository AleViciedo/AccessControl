using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Common;

namespace Domain.Entities.ConfigurationData
{
    public class Supervisor : Person
    {
        List<Operator> Operators {  get; set; }

        public Supervisor() : base()
        {
            Operators = new List<Operator>();
        }

        public Supervisor(string name, string cI, School? formation) : base(name, cI, formation)
        {
            Operators = new List<Operator>();
        }

    }
}
