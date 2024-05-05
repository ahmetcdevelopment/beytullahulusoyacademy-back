using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Attendances;

public interface IAttendanceService
{
    Task<Attendance?> GetAsync(
        Expression<Func<Attendance, bool>> predicate,
        Func<IQueryable<Attendance>, IIncludableQueryable<Attendance, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Attendance>?> GetListAsync(
        Expression<Func<Attendance, bool>>? predicate = null,
        Func<IQueryable<Attendance>, IOrderedQueryable<Attendance>>? orderBy = null,
        Func<IQueryable<Attendance>, IIncludableQueryable<Attendance, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Attendance> AddAsync(Attendance attendance);
    Task<Attendance> UpdateAsync(Attendance attendance);
    Task<Attendance> DeleteAsync(Attendance attendance, bool permanent = false);
}
