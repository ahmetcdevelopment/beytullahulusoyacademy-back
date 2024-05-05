using FluentValidation;

namespace Application.Features.TrainingRooms.Commands.Update;

public class UpdateTrainingRoomCommandValidator : AbstractValidator<UpdateTrainingRoomCommand>
{
    public UpdateTrainingRoomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
        RuleFor(c => c.Enlem).NotEmpty();
        RuleFor(c => c.Boylam).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Picture).NotEmpty();
    }
}