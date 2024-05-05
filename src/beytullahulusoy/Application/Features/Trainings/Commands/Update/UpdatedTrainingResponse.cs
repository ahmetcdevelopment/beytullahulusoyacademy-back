using NArchitecture.Core.Application.Responses;

namespace Application.Features.Trainings.Commands.Update;

public class UpdatedTrainingResponse : IResponse
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GroupId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Note { get; set; }
}