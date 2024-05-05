using Application.Features.Attendances.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Attendances.Constants.AttendancesOperationClaims;

namespace Application.Features.Attendances.Queries.GetList;

public class GetListAttendanceQuery : IRequest<GetListResponse<GetListAttendanceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListAttendances({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetAttendances";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAttendanceQueryHandler : IRequestHandler<GetListAttendanceQuery, GetListResponse<GetListAttendanceListItemDto>>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public GetListAttendanceQueryHandler(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAttendanceListItemDto>> Handle(GetListAttendanceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Attendance> attendances = await _attendanceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAttendanceListItemDto> response = _mapper.Map<GetListResponse<GetListAttendanceListItemDto>>(attendances);
            return response;
        }
    }
}