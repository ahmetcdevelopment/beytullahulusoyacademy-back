using NArchitecture.Core.Application.Responses;

namespace Application.Features.Trainings.Commands.Delete;

public class DeletedTrainingResponse : IResponse
{
    public int Id { get; set; }
}