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

namespace Application.Features.Attendances.Commands.Create;

public class CreateAttendanceCommand : IRequest<CreatedAttendanceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int TrainingId { get; set; }
    public Guid UserId { get; set; }
    public bool IsThere { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, AttendancesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAttendances"];

    public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, CreatedAttendanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly AttendanceBusinessRules _attendanceBusinessRules;

        public CreateAttendanceCommandHandler(IMapper mapper, IAttendanceRepository attendanceRepository,
                                         AttendanceBusinessRules attendanceBusinessRules)
        {
            _mapper = mapper;
            _attendanceRepository = attendanceRepository;
            _attendanceBusinessRules = attendanceBusinessRules;
        }

        public async Task<CreatedAttendanceResponse> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
        {
            Attendance attendance = _mapper.Map<Attendance>(request);

            await _attendanceRepository.AddAsync(attendance);

            CreatedAttendanceResponse response = _mapper.Map<CreatedAttendanceResponse>(attendance);
            return response;
        }
    }
}