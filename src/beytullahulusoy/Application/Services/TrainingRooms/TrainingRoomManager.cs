using Application.Features.TrainingRooms.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TrainingRooms;

public class TrainingRoomManager : ITrainingRoomService
{
    private readonly ITrainingRoomRepository _trainingRoomRepository;
    private readonly TrainingRoomBusinessRules _trainingRoomBusinessRules;

    public TrainingRoomManager(ITrainingRoomRepository trainingRoomRepository, TrainingRoomBusinessRules trainingRoomBusinessRules)
    {
        _trainingRoomRepository = trainingRoomRepository;
        _trainingRoomBusinessRules = trainingRoomBusinessRules;
    }

    public async Task<TrainingRoom?> GetAsync(
        Expression<Func<TrainingRoom, bool>> predicate,
        Func<IQueryable<TrainingRoom>, IIncludableQueryable<TrainingRoom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TrainingRoom? trainingRoom = await _trainingRoomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return trainingRoom;
    }

    public async Task<IPaginate<TrainingRoom>?> GetListAsync(
        Expression<Func<TrainingRoom, bool>>? predicate = null,
        Func<IQueryable<TrainingRoom>, IOrderedQueryable<TrainingRoom>>? orderBy = null,
        Func<IQueryable<TrainingRoom>, IIncludableQueryable<TrainingRoom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TrainingRoom> trainingRoomList = await _trainingRoomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return trainingRoomList;
    }

    public async Task<TrainingRoom> AddAsync(TrainingRoom trainingRoom)
    {
        TrainingRoom addedTrainingRoom = await _trainingRoomRepository.AddAsync(trainingRoom);

        return addedTrainingRoom;
    }

    public async Task<TrainingRoom> UpdateAsync(TrainingRoom trainingRoom)
    {
        TrainingRoom updatedTrainingRoom = await _trainingRoomRepository.UpdateAsync(trainingRoom);

        return updatedTrainingRoom;
    }

    public async Task<TrainingRoom> DeleteAsync(TrainingRoom trainingRoom, bool permanent = false)
    {
        TrainingRoom deletedTrainingRoom = await _trainingRoomRepository.DeleteAsync(trainingRoom);

        return deletedTrainingRoom;
    }
}
