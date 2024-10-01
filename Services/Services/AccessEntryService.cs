using AccessControl.Contracts;
using AccessControl.GrpcProtos;
using Contracts.Entities;
using Contracts.ValueObjects;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace AccessControl.Services.Services
{
    public class AccessEntryService : AccessEntry.AccessEntryBase
    {
        private readonly IAccessEntryRepository _accessEntryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccessEntryService(IAccessEntryRepository accessEntryRepository, IUnitOfWork unitOfWork)
        {
            _accessEntryRepository = accessEntryRepository;
            _unitOfWork = unitOfWork;
        }

        public override Task<AccessEntryDTO> CreateAccessEntry(CreateAccessEntryRequest request, ServerCallContext context)
        {
            return base.CreateAccessEntry(request, context);
        }

        public override Task<Empty> DeleteAccessEntry(DeleteRequest request, ServerCallContext context)
        {
            return base.DeleteAccessEntry(request, context);
        }

        public override Task<NullableAccessEntryDTO> GetAccessEntry(GetRequest request, ServerCallContext context)
        {
            return base.GetAccessEntry(request, context);
        }

        public override Task<AccessEntries> GetAllAccessEntries(Empty request, ServerCallContext context)
        {
            return base.GetAllAccessEntries(request, context);
        }

        public override Task<Empty> UpdateAccessEntry(AccessEntryDTO request, ServerCallContext context)
        {
            return base.UpdateAccessEntry(request, context);
        }
    }
}
