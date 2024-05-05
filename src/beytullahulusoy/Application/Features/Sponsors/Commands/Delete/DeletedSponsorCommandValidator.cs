using FluentValidation;

namespace Application.Features.Sponsors.Commands.Delete;

public class DeleteSponsorCommandValidator : AbstractValidator<DeleteSponsorCommand>
{
    public DeleteSponsorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}