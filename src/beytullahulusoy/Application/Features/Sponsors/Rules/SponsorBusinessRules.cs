using Application.Features.Sponsors.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Sponsors.Rules;

public class SponsorBusinessRules : BaseBusinessRules
{
    private readonly ISponsorRepository _sponsorRepository;
    private readonly ILocalizationService _localizationService;

    public SponsorBusinessRules(ISponsorRepository sponsorRepository, ILocalizationService localizationService)
    {
        _sponsorRepository = sponsorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SponsorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SponsorShouldExistWhenSelected(Sponsor? sponsor)
    {
        if (sponsor == null)
            await throwBusinessException(SponsorsBusinessMessages.SponsorNotExists);
    }

    public async Task SponsorIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Sponsor? sponsor = await _sponsorRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SponsorShouldExistWhenSelected(sponsor);
    }
}