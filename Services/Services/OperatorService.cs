using AccessControl.Contracts;
using AccessControl.GrpcProtos;
using Contracts.Entities;
using Contracts.ValueObjects;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace AccessControl.Services.Services
{
    public class OperatorService : Operator.OperatorBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OperatorService(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public override Task<OperatorDTO> CreateOperator(CreateOperatorRequest request, ServerCallContext context)
        {
            return base.CreateOperator(request, context);
        }

        public override Task<Empty> DeleteOperator(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteOperator(request, context);
        }

        public override Task<Operators> GetAllOperators(Empty request, ServerCallContext context)
        {
            return base.GetAllOperators(request, context);
        }

        public override Task<NullableOperatorDTO> GetOperator(GetRequest request, ServerCallContext context)
        {
            return base.GetOperator(request, context);
        }

        public override Task<Empty> UpdateOperator(OperatorDTO request, ServerCallContext context)
        {
            return base.UpdateOperator(request, context);
        }
    }
}
