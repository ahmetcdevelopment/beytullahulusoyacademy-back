using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sponsors.Commands.Create;

public class CreatedSponsorResponse : IResponse
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Logo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}