using Application.Features.Attendances.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Attendances;

public class AttendanceManager : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly AttendanceBusinessRules _attendanceBusinessRules;

    public AttendanceManager(IAttendanceRepository attendanceRepository, AttendanceBusinessRules attendanceBusinessRules)
    {
        _attendanceRepository = attendanceRepository;
        _attendanceBusinessRules = attendanceBusinessRules;
    }

    public async Task<Attendance?> GetAsync(
        Expression<Func<Attendance, bool>> predicate,
        Func<IQueryable<Attendance>, IIncludableQueryable<Attendance, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Attendance? attendance = await _attendanceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return attendance;
    }

    public async Task<IPaginate<Attendance>?> GetListAsync(
        Expression<Func<Attendance, bool>>? predicate = null,
        Func<IQueryable<Attendance>, IOrderedQueryable<Attendance>>? orderBy = null,
        Func<IQueryable<Attendance>, IIncludableQueryable<Attendance, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Attendance> attendanceList = await _attendanceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return attendanceList;
    }

    public async Task<Attendance> AddAsync(Attendance attendance)
    {
        Attendance addedAttendance = await _attendanceRepository.AddAsync(attendance);

        return addedAttendance;
    }

    public async Task<Attendance> UpdateAsync(Attendance attendance)
    {
        Attendance updatedAttendance = await _attendanceRepository.UpdateAsync(attendance);

        return updatedAttendance;
    }

    public async Task<Attendance> DeleteAsync(Attendance attendance, bool permanent = false)
    {
        Attendance deletedAttendance = await _attendanceRepository.DeleteAsync(attendance);

        return deletedAttendance;
    }
}
