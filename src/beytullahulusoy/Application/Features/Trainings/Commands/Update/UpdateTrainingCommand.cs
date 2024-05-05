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

namespace Application.Features.Trainings.Commands.Update;

public class UpdateTrainingCommand : IRequest<UpdatedTrainingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GroupId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Note { get; set; }

    public string[] Roles => [Admin, Write, TrainingsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTrainings"];

    public class UpdateTrainingCommandHandler : IRequestHandler<UpdateTrainingCommand, UpdatedTrainingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;
        private readonly TrainingBusinessRules _trainingBusinessRules;

        public UpdateTrainingCommandHandler(IMapper mapper, ITrainingRepository trainingRepository,
                                         TrainingBusinessRules trainingBusinessRules)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
            _trainingBusinessRules = trainingBusinessRules;
        }

        public async Task<UpdatedTrainingResponse> Handle(UpdateTrainingCommand request, CancellationToken cancellationToken)
        {
            Training? training = await _trainingRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _trainingBusinessRules.TrainingShouldExistWhenSelected(training);
            training = _mapper.Map(request, training);

            await _trainingRepository.UpdateAsync(training!);

            UpdatedTrainingResponse response = _mapper.Map<UpdatedTrainingResponse>(training);
            return response;
        }
    }
}