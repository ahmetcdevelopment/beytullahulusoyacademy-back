using FluentValidation;

namespace Application.Features.Attendances.Commands.Update;

public class UpdateAttendanceCommandValidator : AbstractValidator<UpdateAttendanceCommand>
{
    public UpdateAttendanceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TrainingId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.IsThere).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}