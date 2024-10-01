using AccessControl.Domain.Common;
using AccessControl.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Entities.ConfigurationData
{
    public class Operator : Person
    {
        public Supervisor? Supervisor { get; set; }
        
        //public Guid SupervisorID { get; set; }

        public Operator() : base() { }

        public Operator (Supervisor? supervisor, string name, string ci, School? formation, Guid id) : base(name, ci, formation, id)
        {
            Supervisor = supervisor;
        }

        public void AddProcess(Process process)
        {
            this.Processes.Add(process);
            Supervisor.UpdateProcesses(this);
        }
    }

    //public Operator(Guid SuperId, string name, string cI, School? formation, Guid id) : base(name, cI, formation, id)
    //    {
    //        SupervisorID = SuperId;
    //    }
    //}
}
