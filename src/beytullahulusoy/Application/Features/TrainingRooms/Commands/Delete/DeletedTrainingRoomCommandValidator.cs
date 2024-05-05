using FluentValidation;

namespace Application.Features.TrainingRooms.Commands.Delete;

public class DeleteTrainingRoomCommandValidator : AbstractValidator<DeleteTrainingRoomCommand>
{
    public DeleteTrainingRoomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}