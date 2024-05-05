using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISponsorRepository : IAsyncRepository<Sponsor, int>, IRepository<Sponsor, int>
{
}