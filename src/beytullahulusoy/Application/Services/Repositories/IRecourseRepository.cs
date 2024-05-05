using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRecourseRepository : IAsyncRepository<Recourse, int>, IRepository<Recourse, int>
{
}