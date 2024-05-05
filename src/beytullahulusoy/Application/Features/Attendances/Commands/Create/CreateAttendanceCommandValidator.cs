using FluentValidation;

namespace Application.Features.Attendances.Commands.Create;

public class CreateAttendanceCommandValidator : AbstractValidator<CreateAttendanceCommand>
{
    public CreateAttendanceCommandValidator()
    {
        RuleFor(c => c.TrainingId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.IsThere).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}