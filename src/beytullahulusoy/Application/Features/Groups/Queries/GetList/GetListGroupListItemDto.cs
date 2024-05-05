using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Groups.Queries.GetList;

public class GetListGroupListItemDto : IDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsTrainerGroup { get; set; }
}