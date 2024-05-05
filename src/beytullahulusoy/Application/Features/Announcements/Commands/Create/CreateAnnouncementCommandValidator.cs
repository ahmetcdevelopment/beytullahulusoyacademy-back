using FluentValidation;

namespace Application.Features.Announcements.Commands.Create;

public class CreateAnnouncementCommandValidator : AbstractValidator<CreateAnnouncementCommand>
{
    public CreateAnnouncementCommandValidator()
    {
        RuleFor(c => c.Picture).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.PrivacyStatus).NotEmpty();
    }
}