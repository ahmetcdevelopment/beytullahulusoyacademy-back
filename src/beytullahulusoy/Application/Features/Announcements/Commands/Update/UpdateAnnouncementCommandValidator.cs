using FluentValidation;

namespace Application.Features.Announcements.Commands.Update;

public class UpdateAnnouncementCommandValidator : AbstractValidator<UpdateAnnouncementCommand>
{
    public UpdateAnnouncementCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Picture).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
        RuleFor(c => c.PrivacyStatus).NotEmpty();
    }
}