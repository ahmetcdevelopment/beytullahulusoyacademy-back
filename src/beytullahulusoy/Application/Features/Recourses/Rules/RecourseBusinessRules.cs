using Application.Features.Recourses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Recourses.Rules;

public class RecourseBusinessRules : BaseBusinessRules
{
    private readonly IRecourseRepository _recourseRepository;
    private readonly ILocalizationService _localizationService;

    public RecourseBusinessRules(IRecourseRepository recourseRepository, ILocalizationService localizationService)
    {
        _recourseRepository = recourseRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RecoursesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RecourseShouldExistWhenSelected(Recourse? recourse)
    {
        if (recourse == null)
            await throwBusinessException(RecoursesBusinessMessages.RecourseNotExists);
    }

    public async Task RecourseIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Recourse? recourse = await _recourseRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RecourseShouldExistWhenSelected(recourse);
    }
}