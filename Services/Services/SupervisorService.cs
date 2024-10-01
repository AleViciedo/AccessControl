using AccessControl.Contracts;
using AccessControl.GrpcProtos;
using Contracts.Entities;
using Contracts.ValueObjects;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace AccessControl.Services.Services
{
    public class SupervisorService : Supervisor.SupervisorBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SupervisorService(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }
        public override Task<SupervisorDTO> CreateSupervisor(CreateSupervisorRequest request, ServerCallContext context)
        {
            return base.CreateSupervisor(request, context);
        }

        public override Task<Empty> DeleteSupervisor(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteSupervisor(request, context);
        }

        public override Task<Supervisors> GetAllSupervisors(Empty request, ServerCallContext context)
        {
            return base.GetAllSupervisors(request, context);
        }

        public override Task<NullableSupervisorDTO> GetSupervisor(GetRequest request, ServerCallContext context)
        {
            return base.GetSupervisor(request, context);
        }

        public override Task<Empty> UpdateSupervisor(SupervisorDTO request, ServerCallContext context)
        {
            return base.UpdateSupervisor(request, context);
        }
    }
}
