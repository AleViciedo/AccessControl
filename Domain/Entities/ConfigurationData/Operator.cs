using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ConfigurationData
{
    public class Operator : Person
    {
        Supervisor? Supervisor { get; set; }


        public Operator() :base() { }
        public Operator(Supervisor? supervisor, string name, string cI, School? formation) : base (name, cI, formation)
        {
            Supervisor = supervisor;
        }
    }
}
