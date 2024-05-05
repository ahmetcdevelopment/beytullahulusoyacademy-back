using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sponsors.Commands.Delete;

public class DeletedSponsorResponse : IResponse
{
    public int Id { get; set; }
}