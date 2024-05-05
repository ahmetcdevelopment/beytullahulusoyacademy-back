using Application.Features.TrainingRooms.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.TrainingRooms.Rules;

public class TrainingRoomBusinessRules : BaseBusinessRules
{
    private readonly ITrainingRoomRepository _trainingRoomRepository;
    private readonly ILocalizationService _localizationService;

    public TrainingRoomBusinessRules(ITrainingRoomRepository trainingRoomRepository, ILocalizationService localizationService)
    {
        _trainingRoomRepository = trainingRoomRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TrainingRoomsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TrainingRoomShouldExistWhenSelected(TrainingRoom? trainingRoom)
    {
        if (trainingRoom == null)
            await throwBusinessException(TrainingRoomsBusinessMessages.TrainingRoomNotExists);
    }

    public async Task TrainingRoomIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        TrainingRoom? trainingRoom = await _trainingRoomRepository.GetAsync(
            predicate: tr => tr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TrainingRoomShouldExistWhenSelected(trainingRoom);
    }
}