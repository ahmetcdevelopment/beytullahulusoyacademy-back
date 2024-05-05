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

namespace Application.Features.TrainingRooms.Commands.Update;

public class UpdateTrainingRoomCommand : IRequest<UpdatedTrainingRoomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public double Enlem { get; set; }
    public double Boylam { get; set; }
    public string Address { get; set; }
    public string Picture { get; set; }

    public string[] Roles => [Admin, Write, TrainingRoomsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTrainingRooms"];

    public class UpdateTrainingRoomCommandHandler : IRequestHandler<UpdateTrainingRoomCommand, UpdatedTrainingRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRoomRepository _trainingRoomRepository;
        private readonly TrainingRoomBusinessRules _trainingRoomBusinessRules;

        public UpdateTrainingRoomCommandHandler(IMapper mapper, ITrainingRoomRepository trainingRoomRepository,
                                         TrainingRoomBusinessRules trainingRoomBusinessRules)
        {
            _mapper = mapper;
            _trainingRoomRepository = trainingRoomRepository;
            _trainingRoomBusinessRules = trainingRoomBusinessRules;
        }

        public async Task<UpdatedTrainingRoomResponse> Handle(UpdateTrainingRoomCommand request, CancellationToken cancellationToken)
        {
            TrainingRoom? trainingRoom = await _trainingRoomRepository.GetAsync(predicate: tr => tr.Id == request.Id, cancellationToken: cancellationToken);
            await _trainingRoomBusinessRules.TrainingRoomShouldExistWhenSelected(trainingRoom);
            trainingRoom = _mapper.Map(request, trainingRoom);

            await _trainingRoomRepository.UpdateAsync(trainingRoom!);

            UpdatedTrainingRoomResponse response = _mapper.Map<UpdatedTrainingRoomResponse>(trainingRoom);
            return response;
        }
    }
}