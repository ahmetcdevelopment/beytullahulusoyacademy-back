using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TrainingRoomRepository : EfRepositoryBase<TrainingRoom, int, BaseDbContext>, ITrainingRoomRepository
{
    public TrainingRoomRepository(BaseDbContext context) : base(context)
    {
    }
}