using FluentValidation;

namespace Application.Features.Trainings.Commands.Delete;

public class DeleteTrainingCommandValidator : AbstractValidator<DeleteTrainingCommand>
{
    public DeleteTrainingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}