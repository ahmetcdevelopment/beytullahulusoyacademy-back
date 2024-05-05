using Application.Features.Sponsors.Constants;
using Application.Features.Sponsors.Constants;
using Application.Features.Sponsors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sponsors.Constants.SponsorsOperationClaims;

namespace Application.Features.Sponsors.Commands.Delete;

public class DeleteSponsorCommand : IRequest<DeletedSponsorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, SponsorsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSponsors"];

    public class DeleteSponsorCommandHandler : IRequestHandler<DeleteSponsorCommand, DeletedSponsorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly SponsorBusinessRules _sponsorBusinessRules;

        public DeleteSponsorCommandHandler(IMapper mapper, ISponsorRepository sponsorRepository,
                                         SponsorBusinessRules sponsorBusinessRules)
        {
            _mapper = mapper;
            _sponsorRepository = sponsorRepository;
            _sponsorBusinessRules = sponsorBusinessRules;
        }

        public async Task<DeletedSponsorResponse> Handle(DeleteSponsorCommand request, CancellationToken cancellationToken)
        {
            Sponsor? sponsor = await _sponsorRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sponsorBusinessRules.SponsorShouldExistWhenSelected(sponsor);

            await _sponsorRepository.DeleteAsync(sponsor!);

            DeletedSponsorResponse response = _mapper.Map<DeletedSponsorResponse>(sponsor);
            return response;
        }
    }
}