using NArchitecture.Core.Application.Responses;

namespace Application.Features.Groups.Commands.Update;

public class UpdatedGroupResponse : IResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsTrainerGroup { get; set; }
}