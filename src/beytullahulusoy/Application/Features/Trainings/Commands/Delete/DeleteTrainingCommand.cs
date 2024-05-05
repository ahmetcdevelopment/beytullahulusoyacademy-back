using Application.Features.Trainings.Constants;
using Application.Features.Trainings.Constants;
using Application.Features.Trainings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Trainings.Constants.TrainingsOperationClaims;

namespace Application.Features.Trainings.Commands.Delete;

public class DeleteTrainingCommand : IRequest<DeletedTrainingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, TrainingsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTrainings"];

    public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand, DeletedTrainingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;
        private readonly TrainingBusinessRules _trainingBusinessRules;

        public DeleteTrainingCommandHandler(IMapper mapper, ITrainingRepository trainingRepository,
                                         TrainingBusinessRules trainingBusinessRules)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
            _trainingBusinessRules = trainingBusinessRules;
        }

        public async Task<DeletedTrainingResponse> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
        {
            Training? training = await _trainingRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _trainingBusinessRules.TrainingShouldExistWhenSelected(training);

            await _trainingRepository.DeleteAsync(training!);

            DeletedTrainingResponse response = _mapper.Map<DeletedTrainingResponse>(training);
            return response;
        }
    }
}