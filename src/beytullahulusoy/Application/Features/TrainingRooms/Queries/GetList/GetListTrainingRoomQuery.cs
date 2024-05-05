using Application.Features.TrainingRooms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.TrainingRooms.Constants.TrainingRoomsOperationClaims;

namespace Application.Features.TrainingRooms.Queries.GetList;

public class GetListTrainingRoomQuery : IRequest<GetListResponse<GetListTrainingRoomListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTrainingRooms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTrainingRooms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTrainingRoomQueryHandler : IRequestHandler<GetListTrainingRoomQuery, GetListResponse<GetListTrainingRoomListItemDto>>
    {
        private readonly ITrainingRoomRepository _trainingRoomRepository;
        private readonly IMapper _mapper;

        public GetListTrainingRoomQueryHandler(ITrainingRoomRepository trainingRoomRepository, IMapper mapper)
        {
            _trainingRoomRepository = trainingRoomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTrainingRoomListItemDto>> Handle(GetListTrainingRoomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TrainingRoom> trainingRooms = await _trainingRoomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTrainingRoomListItemDto> response = _mapper.Map<GetListResponse<GetListTrainingRoomListItemDto>>(trainingRooms);
            return response;
        }
    }
}