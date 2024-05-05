using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TrainingRooms;

public interface ITrainingRoomService
{
    Task<TrainingRoom?> GetAsync(
        Expression<Func<TrainingRoom, bool>> predicate,
        Func<IQueryable<TrainingRoom>, IIncludableQueryable<TrainingRoom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TrainingRoom>?> GetListAsync(
        Expression<Func<TrainingRoom, bool>>? predicate = null,
        Func<IQueryable<TrainingRoom>, IOrderedQueryable<TrainingRoom>>? orderBy = null,
        Func<IQueryable<TrainingRoom>, IIncludableQueryable<TrainingRoom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TrainingRoom> AddAsync(TrainingRoom trainingRoom);
    Task<TrainingRoom> UpdateAsync(TrainingRoom trainingRoom);
    Task<TrainingRoom> DeleteAsync(TrainingRoom trainingRoom, bool permanent = false);
}
