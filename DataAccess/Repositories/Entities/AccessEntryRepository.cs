using AccessControl.DataAccess.Context;
using AccessControl.DataAccess.Repositories.Common;
using AccessControl.Domain.Entities.HistoricalData;
using Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.DataAccess.Repositories.Entities
{
    public class AccessEntryRepository : RepositoryBase, IAccessEntryRepository
    {
        public AccessEntryRepository(ApplicationContext context) : base(context) { }
        public void AddAccessEntry(AccessEntry accessEntry)
        {
            _context.AccessEntries.Add(accessEntry);
        }
        public void DeleteAccessEntry(AccessEntry accessEntry)
        {
            _context.AccessEntries.Remove(accessEntry);
        }

        public IEnumerable<AccessEntry> GetAllAccessEntries()
        {
            return _context.AccessEntries.ToList();
        }

        public AccessEntry? GetAccessEntryById(Guid id)
        {
            return _context.AccessEntries.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateAccessEntry(AccessEntry accessEntry)
        {
            _context.AccessEntries.Update(accessEntry);
        }
    }
}
