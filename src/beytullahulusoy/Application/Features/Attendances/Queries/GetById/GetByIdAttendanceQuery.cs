using Application.Features.Attendances.Constants;
using Application.Features.Attendances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Attendances.Constants.AttendancesOperationClaims;

namespace Application.Features.Attendances.Queries.GetById;

public class GetByIdAttendanceQuery : IRequest<GetByIdAttendanceResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAttendanceQueryHandler : IRequestHandler<GetByIdAttendanceQuery, GetByIdAttendanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly AttendanceBusinessRules _attendanceBusinessRules;

        public GetByIdAttendanceQueryHandler(IMapper mapper, IAttendanceRepository attendanceRepository, AttendanceBusinessRules attendanceBusinessRules)
        {
            _mapper = mapper;
            _attendanceRepository = attendanceRepository;
            _attendanceBusinessRules = attendanceBusinessRules;
        }

        public async Task<GetByIdAttendanceResponse> Handle(GetByIdAttendanceQuery request, CancellationToken cancellationToken)
        {
            Attendance? attendance = await _attendanceRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _attendanceBusinessRules.AttendanceShouldExistWhenSelected(attendance);

            GetByIdAttendanceResponse response = _mapper.Map<GetByIdAttendanceResponse>(attendance);
            return response;
        }
    }
}