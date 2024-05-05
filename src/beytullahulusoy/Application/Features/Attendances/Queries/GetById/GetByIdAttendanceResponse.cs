using NArchitecture.Core.Application.Responses;

namespace Application.Features.Attendances.Queries.GetById;

public class GetByIdAttendanceResponse : IResponse
{
    public int Id { get; set; }
    public int TrainingId { get; set; }
    public Guid UserId { get; set; }
    public bool IsThere { get; set; }
    public string Description { get; set; }
}