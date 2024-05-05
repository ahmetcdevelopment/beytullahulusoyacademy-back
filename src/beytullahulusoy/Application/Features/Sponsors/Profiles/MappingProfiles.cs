using Application.Features.Sponsors.Commands.Create;
using Application.Features.Sponsors.Commands.Delete;
using Application.Features.Sponsors.Commands.Update;
using Application.Features.Sponsors.Queries.GetById;
using Application.Features.Sponsors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Sponsors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Sponsor, CreateSponsorCommand>().ReverseMap();
        CreateMap<Sponsor, CreatedSponsorResponse>().ReverseMap();
        CreateMap<Sponsor, UpdateSponsorCommand>().ReverseMap();
        CreateMap<Sponsor, UpdatedSponsorResponse>().ReverseMap();
        CreateMap<Sponsor, DeleteSponsorCommand>().ReverseMap();
        CreateMap<Sponsor, DeletedSponsorResponse>().ReverseMap();
        CreateMap<Sponsor, GetByIdSponsorResponse>().ReverseMap();
        CreateMap<Sponsor, GetListSponsorListItemDto>().ReverseMap();
        CreateMap<IPaginate<Sponsor>, GetListResponse<GetListSponsorListItemDto>>().ReverseMap();
    }
}