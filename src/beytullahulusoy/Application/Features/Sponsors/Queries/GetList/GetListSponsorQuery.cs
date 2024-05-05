using Application.Features.Sponsors.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Sponsors.Constants.SponsorsOperationClaims;

namespace Application.Features.Sponsors.Queries.GetList;

public class GetListSponsorQuery : IRequest<GetListResponse<GetListSponsorListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSponsors({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSponsors";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSponsorQueryHandler : IRequestHandler<GetListSponsorQuery, GetListResponse<GetListSponsorListItemDto>>
    {
        private readonly ISponsorRepository _sponsorRepository;
        private readonly IMapper _mapper;

        public GetListSponsorQueryHandler(ISponsorRepository sponsorRepository, IMapper mapper)
        {
            _sponsorRepository = sponsorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSponsorListItemDto>> Handle(GetListSponsorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Sponsor> sponsors = await _sponsorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSponsorListItemDto> response = _mapper.Map<GetListResponse<GetListSponsorListItemDto>>(sponsors);
            return response;
        }
    }
}