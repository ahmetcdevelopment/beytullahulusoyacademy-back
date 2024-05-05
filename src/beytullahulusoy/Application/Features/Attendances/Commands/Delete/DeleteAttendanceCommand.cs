using Application.Features.Attendances.Constants;
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

namespace Application.Features.Attendances.Commands.Delete;

public class DeleteAttendanceCommand : IRequest<DeletedAttendanceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, AttendancesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAttendances"];

    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand, DeletedAttendanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly AttendanceBusinessRules _attendanceBusinessRules;

        public DeleteAttendanceCommandHandler(IMapper mapper, IAttendanceRepository attendanceRepository,
                                         AttendanceBusinessRules attendanceBusinessRules)
        {
            _mapper = mapper;
            _attendanceRepository = attendanceRepository;
            _attendanceBusinessRules = attendanceBusinessRules;
        }

        public async Task<DeletedAttendanceResponse> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            Attendance? attendance = await _attendanceRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _attendanceBusinessRules.AttendanceShouldExistWhenSelected(attendance);

            await _attendanceRepository.DeleteAsync(attendance!);

            DeletedAttendanceResponse response = _mapper.Map<DeletedAttendanceResponse>(attendance);
            return response;
        }
    }
}