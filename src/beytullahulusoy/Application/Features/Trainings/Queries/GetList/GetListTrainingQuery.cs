using Application.Features.Trainings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Trainings.Constants.TrainingsOperationClaims;

namespace Application.Features.Trainings.Queries.GetList;

public class GetListTrainingQuery : IRequest<GetListResponse<GetListTrainingListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTrainings({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTrainings";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTrainingQueryHandler : IRequestHandler<GetListTrainingQuery, GetListResponse<GetListTrainingListItemDto>>
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IMapper _mapper;

        public GetListTrainingQueryHandler(ITrainingRepository trainingRepository, IMapper mapper)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTrainingListItemDto>> Handle(GetListTrainingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Training> trainings = await _trainingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTrainingListItemDto> response = _mapper.Map<GetListResponse<GetListTrainingListItemDto>>(trainings);
            return response;
        }
    }
}