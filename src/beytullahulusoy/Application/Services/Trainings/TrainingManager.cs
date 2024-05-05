using Application.Features.Trainings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Trainings;

public class TrainingManager : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly TrainingBusinessRules _trainingBusinessRules;

    public TrainingManager(ITrainingRepository trainingRepository, TrainingBusinessRules trainingBusinessRules)
    {
        _trainingRepository = trainingRepository;
        _trainingBusinessRules = trainingBusinessRules;
    }

    public async Task<Training?> GetAsync(
        Expression<Func<Training, bool>> predicate,
        Func<IQueryable<Training>, IIncludableQueryable<Training, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Training? training = await _trainingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return training;
    }

    public async Task<IPaginate<Training>?> GetListAsync(
        Expression<Func<Training, bool>>? predicate = null,
        Func<IQueryable<Training>, IOrderedQueryable<Training>>? orderBy = null,
        Func<IQueryable<Training>, IIncludableQueryable<Training, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Training> trainingList = await _trainingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return trainingList;
    }

    public async Task<Training> AddAsync(Training training)
    {
        Training addedTraining = await _trainingRepository.AddAsync(training);

        return addedTraining;
    }

    public async Task<Training> UpdateAsync(Training training)
    {
        Training updatedTraining = await _trainingRepository.UpdateAsync(training);

        return updatedTraining;
    }

    public async Task<Training> DeleteAsync(Training training, bool permanent = false)
    {
        Training deletedTraining = await _trainingRepository.DeleteAsync(training);

        return deletedTraining;
    }
}
