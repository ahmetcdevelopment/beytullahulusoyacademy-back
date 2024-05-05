using Application.Features.TrainingRooms.Constants;
using Application.Features.TrainingRooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.TrainingRooms.Constants.TrainingRoomsOperationClaims;

namespace Application.Features.TrainingRooms.Queries.GetById;

public class GetByIdTrainingRoomQuery : IRequest<GetByIdTrainingRoomResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTrainingRoomQueryHandler : IRequestHandler<GetByIdTrainingRoomQuery, GetByIdTrainingRoomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRoomRepository _trainingRoomRepository;
        private readonly TrainingRoomBusinessRules _trainingRoomBusinessRules;

        public GetByIdTrainingRoomQueryHandler(IMapper mapper, ITrainingRoomRepository trainingRoomRepository, TrainingRoomBusinessRules trainingRoomBusinessRules)
        {
            _mapper = mapper;
            _trainingRoomRepository = trainingRoomRepository;
            _trainingRoomBusinessRules = trainingRoomBusinessRules;
        }

        public async Task<GetByIdTrainingRoomResponse> Handle(GetByIdTrainingRoomQuery request, CancellationToken cancellationToken)
        {
            TrainingRoom? trainingRoom = await _trainingRoomRepository.GetAsync(predicate: tr => tr.Id == request.Id, cancellationToken: cancellationToken);
            await _trainingRoomBusinessRules.TrainingRoomShouldExistWhenSelected(trainingRoom);

            GetByIdTrainingRoomResponse response = _mapper.Map<GetByIdTrainingRoomResponse>(trainingRoom);
            return response;
        }
    }
}