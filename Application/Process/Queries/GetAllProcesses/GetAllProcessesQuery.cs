using AccessControl.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Application.Process.Queries.GetAllProcesses
{
    public record GetAllProcessesQuery() :IQuery<IEnumerable<Domain.ValueObjects.Process>>;
}
