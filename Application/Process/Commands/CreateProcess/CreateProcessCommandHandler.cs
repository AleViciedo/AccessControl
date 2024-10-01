using AccessControl.Domain.ValueObjects;
using AccessControl.GrpcProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AccessControl.Domain;
using AccessControl.Application.Abstract;
using Contracts.ValueObjects;
using AccessControl.Contracts;

namespace AccessControl.Application.Process.Commands.CreateProcess
{
    public class CreateProcessCommandHandler : ICommandHandler<CreateProcessCommand, Domain.ValueObjects.Process>
    {
        private readonly IProcessRepository _processRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProcessCommandHandler(IProcessRepository processRepository, IUnitOfWork unitOfWork)
        {
            _processRepository = processRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Domain.ValueObjects.Process> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            Domain.ValueObjects.Process result = new Domain.ValueObjects.Process(Guid.NewGuid(), request.Name, request.Products);

            _processRepository.AddProcess(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
