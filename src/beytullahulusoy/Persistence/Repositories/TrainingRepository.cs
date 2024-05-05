using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TrainingRepository : EfRepositoryBase<Training, int, BaseDbContext>, ITrainingRepository
{
    public TrainingRepository(BaseDbContext context) : base(context)
    {
    }
}