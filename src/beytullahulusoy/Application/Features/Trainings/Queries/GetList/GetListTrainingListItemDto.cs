using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Trainings.Queries.GetList;

public class GetListTrainingListItemDto : IDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GroupId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Note { get; set; }
}