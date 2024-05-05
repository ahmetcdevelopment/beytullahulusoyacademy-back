using Application.Features.TrainingRooms.Commands.Create;
using Application.Features.TrainingRooms.Commands.Delete;
using Application.Features.TrainingRooms.Commands.Update;
using Application.Features.TrainingRooms.Queries.GetById;
using Application.Features.TrainingRooms.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TrainingRooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TrainingRoom, CreateTrainingRoomCommand>().ReverseMap();
        CreateMap<TrainingRoom, CreatedTrainingRoomResponse>().ReverseMap();
        CreateMap<TrainingRoom, UpdateTrainingRoomCommand>().ReverseMap();
        CreateMap<TrainingRoom, UpdatedTrainingRoomResponse>().ReverseMap();
        CreateMap<TrainingRoom, DeleteTrainingRoomCommand>().ReverseMap();
        CreateMap<TrainingRoom, DeletedTrainingRoomResponse>().ReverseMap();
        CreateMap<TrainingRoom, GetByIdTrainingRoomResponse>().ReverseMap();
        CreateMap<TrainingRoom, GetListTrainingRoomListItemDto>().ReverseMap();
        CreateMap<IPaginate<TrainingRoom>, GetListResponse<GetListTrainingRoomListItemDto>>().ReverseMap();
    }
}