using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TrainingRooms.Queries.GetList;

public class GetListTrainingRoomListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public double Enlem { get; set; }
    public double Boylam { get; set; }
    public string Address { get; set; }
    public string Picture { get; set; }
}