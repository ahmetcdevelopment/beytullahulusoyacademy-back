using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITrainingRepository : IAsyncRepository<Training, int>, IRepository<Training, int>
{
}