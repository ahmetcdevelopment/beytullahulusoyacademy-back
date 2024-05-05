using Application.Features.Trainings.Commands.Create;
using Application.Features.Trainings.Commands.Delete;
using Application.Features.Trainings.Commands.Update;
using Application.Features.Trainings.Queries.GetById;
using Application.Features.Trainings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Trainings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Training, CreateTrainingCommand>().ReverseMap();
        CreateMap<Training, CreatedTrainingResponse>().ReverseMap();
        CreateMap<Training, UpdateTrainingCommand>().ReverseMap();
        CreateMap<Training, UpdatedTrainingResponse>().ReverseMap();
        CreateMap<Training, DeleteTrainingCommand>().ReverseMap();
        CreateMap<Training, DeletedTrainingResponse>().ReverseMap();
        CreateMap<Training, GetByIdTrainingResponse>().ReverseMap();
        CreateMap<Training, GetListTrainingListItemDto>().ReverseMap();
        CreateMap<IPaginate<Training>, GetListResponse<GetListTrainingListItemDto>>().ReverseMap();
    }
}