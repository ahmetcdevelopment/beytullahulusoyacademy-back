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

namespace Application.Features.Trainings.Commands.Create;

public class CreateTrainingCommand : IRequest<CreatedTrainingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int RoomId { get; set; }
    public int GroupId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Note { get; set; }

    public string[] Roles => [Admin, Write, TrainingsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTrainings"];

    public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, CreatedTrainingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;
        private readonly TrainingBusinessRules _trainingBusinessRules;

        public CreateTrainingCommandHandler(IMapper mapper, ITrainingRepository trainingRepository,
                                         TrainingBusinessRules trainingBusinessRules)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
            _trainingBusinessRules = trainingBusinessRules;
        }

        public async Task<CreatedTrainingResponse> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
        {
            Training training = _mapper.Map<Training>(request);

            await _trainingRepository.AddAsync(training);

            CreatedTrainingResponse response = _mapper.Map<CreatedTrainingResponse>(training);
            return response;
        }
    }
}