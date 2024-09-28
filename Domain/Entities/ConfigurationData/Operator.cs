using AccessControl.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Entities.ConfigurationData
{
    public class Operator : Person
    {
        //Supervisor? Supervisor { get; set; }
        public Guid SupervisorID { get; set; }

        public Operator() : base() { }

    //    public operator (supervisor? supervisor, string name, string ci, school? formation, guid id) : base(name, ci, formation, id)
    //    {
    //        supervisor = supervisor;
    //}

    public Operator(Guid SuperId, string name, string cI, School? formation, Guid id) : base(name, cI, formation, id)
        {
            SupervisorID = SuperId;
        }
    }
}
