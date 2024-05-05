using NArchitecture.Core.Application.Responses;

namespace Application.Features.TrainingRooms.Queries.GetById;

public class GetByIdTrainingRoomResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public double Enlem { get; set; }
    public double Boylam { get; set; }
    public string Address { get; set; }
    public string Picture { get; set; }
}