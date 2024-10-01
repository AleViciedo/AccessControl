using AccessControl.Domain.Entities.ConfigurationData;
using AccessControl.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ValueObjects
{
    public interface IProcessRepository
    {
        void AddProcess(Process process);

        Process? GetProcessById(Guid id);

        IEnumerable<Process> GetAllProcesses();

        void UpdateProcess(Process process);

        void DeleteProcess(Process process);
    }
}
