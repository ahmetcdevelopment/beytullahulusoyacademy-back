using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AttendanceRepository : EfRepositoryBase<Attendance, int, BaseDbContext>, IAttendanceRepository
{
    public AttendanceRepository(BaseDbContext context) : base(context)
    {
    }
}