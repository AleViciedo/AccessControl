using AccessControl.Application.Abstract;
using AccessControl.Application.Process.Commands.UpdateProcess;
using AccessControl.Contracts;
using Contracts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Application.Process.Commands.DeleteProcess
{
    public class DeleteProcessCommandHandler : ICommandHandler<DeleteProcessCommand>
    {
        private readonly IProcessRepository _processRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProcessCommandHandler(IProcessRepository processRepository, IUnitOfWork unitOfWork)
        {
            _processRepository = processRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteProcessCommand request, CancellationToken cancellationToken)
        {
            Domain.ValueObjects.Process processToDelete = _processRepository.GetProcessById(request.Id);
            if (processToDelete is null)
            {
                return Task.CompletedTask;
            }

            _processRepository.DeleteProcess(processToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
