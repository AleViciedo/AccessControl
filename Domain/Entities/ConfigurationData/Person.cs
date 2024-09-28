using Domain;
using Domain.Common;
using System.Runtime.CompilerServices;

namespace Domain.Entities.ConfigurationData
{
    abstract public class Person
    {
        public string Name { get; set; }
        public string CI { get; set; }
        public School? Formation { get; set; }

        public Person()
        {
            Name = string.Empty;
            CI = string.Empty;
            Formation = null;
        }

        public Person(string name, string cI, School? formation)
        {
            Name = name;
            CI = cI;
            Formation = formation;
        }

        public bool ValidPerson()
        {
            
            if (Formation == null || string.IsNullOrEmpty(this.Name) || ValidCI(CI))
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
