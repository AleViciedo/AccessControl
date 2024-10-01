using AccessControl.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.Contracts;
using AccessControl.Domain.ValueObjects;
using Contracts.ValueObjects;
using AccessControl.DataAccess.Context;
using AccessControl.DataAccess.FluentConfiguration.ValueObjects;

namespace AccessControl.DataAccess.Repositories.ValueObjects
{
    public class ProcessRepository : RepositoryBase, IProcessRepository
    {
        public ProcessRepository(ApplicationContext context) : base(context) { }
        public void AddProcess (Process process)
        {
            _context.Processes.Add (process);
        }
        public void DeleteProcess (Process process)
        {
            _context.Processes.Remove (process);
        }

        public IEnumerable<Process> GetAllProcesses()
        {
            return _context.Processes.ToList();
        }

        public Process? GetProcessById(Guid id)
        {
            return _context.Processes.FirstOrDefault(x => x.ProcessId == id);
        }

        public void UpdateProcess(Process process)
        {
            _context.Processes.Update(process);
        }
    }
}
