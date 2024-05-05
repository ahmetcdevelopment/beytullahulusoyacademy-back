using FluentValidation;

namespace Application.Features.Attendances.Commands.Delete;

public class DeleteAttendanceCommandValidator : AbstractValidator<DeleteAttendanceCommand>
{
    public DeleteAttendanceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}