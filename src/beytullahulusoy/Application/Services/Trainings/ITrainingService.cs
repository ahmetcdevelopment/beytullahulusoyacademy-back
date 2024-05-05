using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Trainings;

public interface ITrainingService
{
    Task<Training?> GetAsync(
        Expression<Func<Training, bool>> predicate,
        Func<IQueryable<Training>, IIncludableQueryable<Training, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Training>?> GetListAsync(
        Expression<Func<Training, bool>>? predicate = null,
        Func<IQueryable<Training>, IOrderedQueryable<Training>>? orderBy = null,
        Func<IQueryable<Training>, IIncludableQueryable<Training, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Training> AddAsync(Training training);
    Task<Training> UpdateAsync(Training training);
    Task<Training> DeleteAsync(Training training, bool permanent = false);
}
