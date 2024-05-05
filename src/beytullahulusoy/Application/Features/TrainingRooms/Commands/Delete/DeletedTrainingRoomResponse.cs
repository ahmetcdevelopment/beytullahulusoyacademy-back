using NArchitecture.Core.Application.Responses;

namespace Application.Features.TrainingRooms.Commands.Delete;

public class DeletedTrainingRoomResponse : IResponse
{
    public int Id { get; set; }
}