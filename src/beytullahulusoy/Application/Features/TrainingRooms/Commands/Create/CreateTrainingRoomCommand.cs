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

namespace Application.Features.TrainingRooms.Commands.Create;

public class CreateTrainingRoomCommand : IRequest<CreatedTrainingRoomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Link { get; set; }
    public double Enlem { get; set; }
    public double Boylam { get; set; }
    public string Address { get; set; }
    public string Picture { get; set; }

    public string[] Roles => [Admin, Write, TrainingRoomsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTrainingRooms"];

    public class CreateTrainingRoomCommandHandler : IRequestHandler<CreateTrainingRoomCommand, CreatedTrainingRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRoomRepository _trainingRoomRepository;
        private readonly TrainingRoomBusinessRules _trainingRoomBusinessRules;

        public CreateTrainingRoomCommandHandler(IMapper mapper, ITrainingRoomRepository trainingRoomRepository,
                                         TrainingRoomBusinessRules trainingRoomBusinessRules)
        {
            _mapper = mapper;
            _trainingRoomRepository = trainingRoomRepository;
            _trainingRoomBusinessRules = trainingRoomBusinessRules;
        }

        public async Task<CreatedTrainingRoomResponse> Handle(CreateTrainingRoomCommand request, CancellationToken cancellationToken)
        {
            TrainingRoom trainingRoom = _mapper.Map<TrainingRoom>(request);

            await _trainingRoomRepository.AddAsync(trainingRoom);

            CreatedTrainingRoomResponse response = _mapper.Map<CreatedTrainingRoomResponse>(trainingRoom);
            return response;
        }
    }
}