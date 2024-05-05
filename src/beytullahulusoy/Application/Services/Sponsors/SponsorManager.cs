using Application.Features.Sponsors.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sponsors;

public class SponsorManager : ISponsorService
{
    private readonly ISponsorRepository _sponsorRepository;
    private readonly SponsorBusinessRules _sponsorBusinessRules;

    public SponsorManager(ISponsorRepository sponsorRepository, SponsorBusinessRules sponsorBusinessRules)
    {
        _sponsorRepository = sponsorRepository;
        _sponsorBusinessRules = sponsorBusinessRules;
    }

    public async Task<Sponsor?> GetAsync(
        Expression<Func<Sponsor, bool>> predicate,
        Func<IQueryable<Sponsor>, IIncludableQueryable<Sponsor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Sponsor? sponsor = await _sponsorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return sponsor;
    }

    public async Task<IPaginate<Sponsor>?> GetListAsync(
        Expression<Func<Sponsor, bool>>? predicate = null,
        Func<IQueryable<Sponsor>, IOrderedQueryable<Sponsor>>? orderBy = null,
        Func<IQueryable<Sponsor>, IIncludableQueryable<Sponsor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Sponsor> sponsorList = await _sponsorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sponsorList;
    }

    public async Task<Sponsor> AddAsync(Sponsor sponsor)
    {
        Sponsor addedSponsor = await _sponsorRepository.AddAsync(sponsor);

        return addedSponsor;
    }

    public async Task<Sponsor> UpdateAsync(Sponsor sponsor)
    {
        Sponsor updatedSponsor = await _sponsorRepository.UpdateAsync(sponsor);

        return updatedSponsor;
    }

    public async Task<Sponsor> DeleteAsync(Sponsor sponsor, bool permanent = false)
    {
        Sponsor deletedSponsor = await _sponsorRepository.DeleteAsync(sponsor);

        return deletedSponsor;
    }
}
