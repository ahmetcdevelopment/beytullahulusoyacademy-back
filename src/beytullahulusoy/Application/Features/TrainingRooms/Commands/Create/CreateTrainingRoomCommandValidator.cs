using FluentValidation;

namespace Application.Features.TrainingRooms.Commands.Create;

public class CreateTrainingRoomCommandValidator : AbstractValidator<CreateTrainingRoomCommand>
{
    public CreateTrainingRoomCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
        RuleFor(c => c.Enlem).NotEmpty();
        RuleFor(c => c.Boylam).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Picture).NotEmpty();
    }
}