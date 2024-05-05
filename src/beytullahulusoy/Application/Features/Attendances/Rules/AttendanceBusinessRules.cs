using Application.Features.Attendances.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Attendances.Rules;

public class AttendanceBusinessRules : BaseBusinessRules
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly ILocalizationService _localizationService;

    public AttendanceBusinessRules(IAttendanceRepository attendanceRepository, ILocalizationService localizationService)
    {
        _attendanceRepository = attendanceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AttendancesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AttendanceShouldExistWhenSelected(Attendance? attendance)
    {
        if (attendance == null)
            await throwBusinessException(AttendancesBusinessMessages.AttendanceNotExists);
    }

    public async Task AttendanceIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Attendance? attendance = await _attendanceRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AttendanceShouldExistWhenSelected(attendance);
    }
}