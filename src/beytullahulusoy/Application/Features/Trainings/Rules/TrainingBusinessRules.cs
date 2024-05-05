using Application.Features.Trainings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Trainings.Rules;

public class TrainingBusinessRules : BaseBusinessRules
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly ILocalizationService _localizationService;

    public TrainingBusinessRules(ITrainingRepository trainingRepository, ILocalizationService localizationService)
    {
        _trainingRepository = trainingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TrainingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TrainingShouldExistWhenSelected(Training? training)
    {
        if (training == null)
            await throwBusinessException(TrainingsBusinessMessages.TrainingNotExists);
    }

    public async Task TrainingIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Training? training = await _trainingRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TrainingShouldExistWhenSelected(training);
    }
}