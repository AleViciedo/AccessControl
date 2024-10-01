using AccessControl.Domain.Common;
using AccessControl.Domain.ValueObjects;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AccessControl.Domain.Entities.ConfigurationData
{
    abstract public class Person : Entity
    {
        public string Name { get; set; }
        public string CI { get; set; }
        public School? Formation { get; set; }
        public List<ValueObjects.Process> Processes { get; set; }
        public Person() : base()
        {
            Name = string.Empty;
            CI = string.Empty;
            Formation = null;
            Processes = new List<ValueObjects.Process>();
        }

        public Person(string name, string cI, School? formation, Guid id) : base(id)
        {
            Name = name;
            CI = cI;
            Formation = formation;
            Processes = new List<ValueObjects.Process>();
        }

        public bool ValidPerson()
        {

            if (Formation == null || string.IsNullOrEmpty(Name) || ValidCI(CI))
                return false;
            return true;
        }

        protected bool ValidCI(string cI)
        {
            if (string.IsNullOrEmpty(cI) || cI.Length != 11)
                return false;
            return true;
        }
    }
}
