using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Attendances.Queries.GetList;

public class GetListAttendanceListItemDto : IDto
{
    public int Id { get; set; }
    public int TrainingId { get; set; }
    public Guid UserId { get; set; }
    public bool IsThere { get; set; }
    public string Description { get; set; }
}