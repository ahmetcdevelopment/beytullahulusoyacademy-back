using Application.Features.Attendances.Commands.Create;
using Application.Features.Attendances.Commands.Delete;
using Application.Features.Attendances.Commands.Update;
using Application.Features.Attendances.Queries.GetById;
using Application.Features.Attendances.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Attendances.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Attendance, CreateAttendanceCommand>().ReverseMap();
        CreateMap<Attendance, CreatedAttendanceResponse>().ReverseMap();
        CreateMap<Attendance, UpdateAttendanceCommand>().ReverseMap();
        CreateMap<Attendance, UpdatedAttendanceResponse>().ReverseMap();
        CreateMap<Attendance, DeleteAttendanceCommand>().ReverseMap();
        CreateMap<Attendance, DeletedAttendanceResponse>().ReverseMap();
        CreateMap<Attendance, GetByIdAttendanceResponse>().ReverseMap();
        CreateMap<Attendance, GetListAttendanceListItemDto>().ReverseMap();
        CreateMap<IPaginate<Attendance>, GetListResponse<GetListAttendanceListItemDto>>().ReverseMap();
    }
}