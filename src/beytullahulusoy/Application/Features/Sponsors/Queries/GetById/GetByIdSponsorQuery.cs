using Application.Features.Sponsors.Constants;
using Application.Features.Sponsors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Sponsors.Constants.SponsorsOperationClaims;

namespace Application.Features.Sponsors.Queries.GetById;

public class GetByIdSponsorQuery : IRequest<GetByIdSponsorResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSponsorQueryHandler : IRequestHandler<GetByIdSponsorQuery, GetByIdSponsorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly SponsorBusinessRules _sponsorBusinessRules;

        public GetByIdSponsorQueryHandler(IMapper mapper, ISponsorRepository sponsorRepository, SponsorBusinessRules sponsorBusinessRules)
        {
            _mapper = mapper;
            _sponsorRepository = sponsorRepository;
            _sponsorBusinessRules = sponsorBusinessRules;
        }

        public async Task<GetByIdSponsorResponse> Handle(GetByIdSponsorQuery request, CancellationToken cancellationToken)
        {
            Sponsor? sponsor = await _sponsorRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sponsorBusinessRules.SponsorShouldExistWhenSelected(sponsor);

            GetByIdSponsorResponse response = _mapper.Map<GetByIdSponsorResponse>(sponsor);
            return response;
        }
    }
}