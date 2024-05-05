using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sponsors;

public interface ISponsorService
{
    Task<Sponsor?> GetAsync(
        Expression<Func<Sponsor, bool>> predicate,
        Func<IQueryable<Sponsor>, IIncludableQueryable<Sponsor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Sponsor>?> GetListAsync(
        Expression<Func<Sponsor, bool>>? predicate = null,
        Func<IQueryable<Sponsor>, IOrderedQueryable<Sponsor>>? orderBy = null,
        Func<IQueryable<Sponsor>, IIncludableQueryable<Sponsor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Sponsor> AddAsync(Sponsor sponsor);
    Task<Sponsor> UpdateAsync(Sponsor sponsor);
    Task<Sponsor> DeleteAsync(Sponsor sponsor, bool permanent = false);
}
