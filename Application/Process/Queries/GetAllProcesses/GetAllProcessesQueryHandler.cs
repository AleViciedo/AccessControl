using AccessControl.Application.Abstract;
using AccessControl.Application.Process.Queries.GetProcess;
using Contracts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Application.Process.Queries.GetAllProcesses
{
    public class GetAllProcessesQueryHandler : IQueryHandler<GetAllProcessesQuery, IEnumerable<Domain.ValueObjects.Process>>
    {
        private readonly IProcessRepository _processRepository;

        public GetAllProcessesQueryHandler(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

        public Task<IEnumerable<Domain.ValueObjects.Process>> Handle(GetAllProcessesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_processRepository.GetAllProcesses());
        }
    }
}
