using AccessControl.Contracts;
using AccessControl.GrpcProtos;
using Contracts.ValueObjects;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authentication;

namespace AccessControl.Services.Services
{
    public class ProcessService : Process.ProcessBase
    {
        private readonly IProcessRepository _processRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessService(IProcessRepository processRepository, IUnitOfWork unitOfWork)
        {
            _processRepository = processRepository;
            _unitOfWork = unitOfWork;
        }

        public override Task<ProcessDTO> CreateProcess(CreateProcessRequest request, ServerCallContext context)
        {
            return base.CreateProcess(request, context);
        }

        public override Task<Empty> DeleteProcess(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteProcess(request, context);
        }

        public override Task<Processes> GetAllProcesses(Empty request, ServerCallContext context)
        {
            return base.GetAllProcesses(request, context);
        }

        public override Task<NullableProcessDTO> GetProcess(GetRequest request, ServerCallContext context)
        {
            return base.GetProcess(request, context);
        }

        public override Task<Empty> UpdateProcess(ProcessDTO request, ServerCallContext context)
        {
            return base.UpdateProcess(request, context);
        }
    }
}
