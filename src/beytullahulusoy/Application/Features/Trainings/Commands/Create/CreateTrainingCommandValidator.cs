using FluentValidation;

namespace Application.Features.Trainings.Commands.Create;

public class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
{
    public CreateTrainingCommandValidator()
    {
        RuleFor(c => c.RoomId).NotEmpty();
        RuleFor(c => c.GroupId).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.Note).NotEmpty();
    }
}