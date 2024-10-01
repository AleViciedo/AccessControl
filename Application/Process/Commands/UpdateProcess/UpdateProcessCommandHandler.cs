using AccessControl.Application.Abstract;
using AccessControl.Application.Process.Commands.CreateProcess;
using AccessControl.Contracts;
using AccessControl.Domain.ValueObjects;
using Contracts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Application.Process.Commands.UpdateProcess
{
    public class UpdateProcessCommandHandler : ICommandHandler<UpdateProcessCommand>
    {
        private readonly IProcessRepository _processRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProcessCommandHandler(IProcessRepository processRepository, IUnitOfWork unitOfWork)
        {
            _processRepository = processRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateProcessCommand request, CancellationToken cancellationToken)
        {
            _processRepository.UpdateProcess(request.process);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
