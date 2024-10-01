using AccessControl.Application.Abstract;
using AccessControl.Domain.ValueObjects;
using Contracts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Application.Process.Queries.GetProcess
{
    public class GetProcessQueryHandler :IQueryHandler<GetProcessQuery, Domain.ValueObjects.Process?>
    {
        private readonly IProcessRepository _processRepository;

        public GetProcessQueryHandler(IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

        public Task<Domain.ValueObjects.Process?> Handle(GetProcessQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_processRepository.GetProcessById(request.Id));
        }
    }
}
