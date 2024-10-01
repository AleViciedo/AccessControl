using AccessControl.Domain.Entities.ConfigurationData;
using AccessControl.Domain.Entities.HistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Entities
{
    public interface IAccessEntryRepository
    {
        void AddAccessEntry(AccessEntry accessEntry);

        AccessEntry? GetAccessEntryById(Guid id);

        IEnumerable<AccessEntry> GetAllAccessEntries();

        void UpdateAccessEntry(AccessEntry accessEntry);

        void DeleteAccessEntry(AccessEntry accessEntry);
    }
}
