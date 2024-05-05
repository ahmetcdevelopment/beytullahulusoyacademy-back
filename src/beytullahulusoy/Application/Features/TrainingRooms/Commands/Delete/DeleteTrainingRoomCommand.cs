using Application.Features.TrainingRooms.Constants;
using Application.Features.TrainingRooms.Constants;
using Application.Features.TrainingRooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TrainingRooms.Constants.TrainingRoomsOperationClaims;

namespace Application.Features.TrainingRooms.Commands.Delete;

public class DeleteTrainingRoomCommand : IRequest<DeletedTrainingRoomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, TrainingRoomsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTrainingRooms"];

    public class DeleteTrainingRoomCommandHandler : IRequestHandler<DeleteTrainingRoomCommand, DeletedTrainingRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRoomRepository _trainingRoomRepository;
        private readonly TrainingRoomBusinessRules _trainingRoomBusinessRules;

        public DeleteTrainingRoomCommandHandler(IMapper mapper, ITrainingRoomRepository trainingRoomRepository,
                                         TrainingRoomBusinessRules trainingRoomBusinessRules)
        {
            _mapper = mapper;
            _trainingRoomRepository = trainingRoomRepository;
            _trainingRoomBusinessRules = trainingRoomBusinessRules;
        }

        public async Task<DeletedTrainingRoomResponse> Handle(DeleteTrainingRoomCommand request, CancellationToken cancellationToken)
        {
            TrainingRoom? trainingRoom = await _trainingRoomRepository.GetAsync(predicate: tr => tr.Id == request.Id, cancellationToken: cancellationToken);
            await _trainingRoomBusinessRules.TrainingRoomShouldExistWhenSelected(trainingRoom);

            await _trainingRoomRepository.DeleteAsync(trainingRoom!);

            DeletedTrainingRoomResponse response = _mapper.Map<DeletedTrainingRoomResponse>(trainingRoom);
            return response;
        }
    }
}