using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Sponsors.Queries.GetList;

public class GetListSponsorListItemDto : IDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Logo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}