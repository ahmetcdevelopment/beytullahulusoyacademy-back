using Application.Features.Attendances.Constants;
using Application.Features.Attendances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Attendances.Constants.AttendancesOperationClaims;

namespace Application.Features.Attendances.Commands.Update;

public class UpdateAttendanceCommand : IRequest<UpdatedAttendanceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int TrainingId { get; set; }
    public Guid UserId { get; set; }
    public bool IsThere { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, AttendancesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAttendances"];

    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, UpdatedAttendanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly AttendanceBusinessRules _attendanceBusinessRules;

        public UpdateAttendanceCommandHandler(IMapper mapper, IAttendanceRepository attendanceRepository,
                                         AttendanceBusinessRules attendanceBusinessRules)
        {
            _mapper = mapper;
            _attendanceRepository = attendanceRepository;
            _attendanceBusinessRules = attendanceBusinessRules;
        }

        public async Task<UpdatedAttendanceResponse> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            Attendance? attendance = await _attendanceRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _attendanceBusinessRules.AttendanceShouldExistWhenSelected(attendance);
            attendance = _mapper.Map(request, attendance);

            await _attendanceRepository.UpdateAsync(attendance!);

            UpdatedAttendanceResponse response = _mapper.Map<UpdatedAttendanceResponse>(attendance);
            return response;
        }
    }
}