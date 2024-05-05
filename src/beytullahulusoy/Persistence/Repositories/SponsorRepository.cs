using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SponsorRepository : EfRepositoryBase<Sponsor, int, BaseDbContext>, ISponsorRepository
{
    public SponsorRepository(BaseDbContext context) : base(context)
    {
    }
}