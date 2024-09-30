using AccessControl.Domain.Common;
using AccessControl.Domain.Entities.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Domain.Entities.HistoricalData
{
    public class AccessEntry : Entity
    {
        //public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public DateTime Entry { get; set; }
        public DateTime? Exit { get; set; }
        public bool InBuilding { get; set; }

        public AccessEntry() : base() { }

        //public AccessEntry(Guid id, Guid personId, DateTime entry, DateTime? exit, bool inBuilding) : base(id)
        //{
        //    PersonId = personId;
        //    Entry = entry;
        //    Exit = exit;
        //    InBuilding = inBuilding;
        //}

        public AccessEntry(Guid id, Person person, DateTime entry, DateTime? exit, bool inBuilding) : base(id)
        {
            Person = person;
            Entry = entry;
            Exit = exit;
            InBuilding = inBuilding;
        }
    }
}
