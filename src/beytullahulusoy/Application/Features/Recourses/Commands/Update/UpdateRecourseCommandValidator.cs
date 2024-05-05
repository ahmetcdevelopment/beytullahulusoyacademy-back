using FluentValidation;

namespace Application.Features.Recourses.Commands.Update;

public class UpdateRecourseCommandValidator : AbstractValidator<UpdateRecourseCommand>
{
    public UpdateRecourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.SizeM).NotEmpty();
        RuleFor(c => c.WeightKg).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.Gender).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.RecourseStatus).NotEmpty();
    }
}