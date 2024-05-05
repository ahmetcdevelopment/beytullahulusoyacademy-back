using FluentValidation;

namespace Application.Features.Trainings.Commands.Update;

public class UpdateTrainingCommandValidator : AbstractValidator<UpdateTrainingCommand>
{
    public UpdateTrainingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RoomId).NotEmpty();
        RuleFor(c => c.GroupId).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.Note).NotEmpty();
    }
}