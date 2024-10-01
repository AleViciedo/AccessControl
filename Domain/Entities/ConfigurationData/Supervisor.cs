using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Domain.Common;
using AccessControl.Domain.ValueObjects;

namespace AccessControl.Domain.Entities.ConfigurationData
{
    public class Supervisor : Person
    {
        public List<Operator> Operators { get; set; }

        public Supervisor() : base()
        {
            Operators = new List<Operator>();
        }

        public Supervisor(string name, string cI, School? formation, Guid id) : base(name, cI, formation, id)
        {
            Operators = new List<Operator>();
        }
        public void AddOperator(Operator oper)
        {
            if (oper.Processes != null)
            {
                foreach (ValueObjects.Process pro in oper.Processes)
                {
                    if (!this.Processes.Contains(pro))
                    {
                        this.Processes.Add(pro);
                    }
                }
            }
            this.Operators.Add(oper);
            oper.Supervisor = this;
        }

        internal void UpdateProcesses(Operator solicitant)
        {
            foreach (ValueObjects.Process pro in solicitant.Processes)
            {
                if (!this.Processes.Contains(pro))
                {
                    this.Processes.Add(pro);
                }
            }
        }

        
    }
}
