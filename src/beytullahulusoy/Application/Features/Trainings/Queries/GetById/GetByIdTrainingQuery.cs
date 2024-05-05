using Application.Features.Trainings.Constants;
using Application.Features.Trainings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Trainings.Constants.TrainingsOperationClaims;

namespace Application.Features.Trainings.Queries.GetById;

public class GetByIdTrainingQuery : IRequest<GetByIdTrainingResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTrainingQueryHandler : IRequestHandler<GetByIdTrainingQuery, GetByIdTrainingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;
        private readonly TrainingBusinessRules _trainingBusinessRules;

        public GetByIdTrainingQueryHandler(IMapper mapper, ITrainingRepository trainingRepository, TrainingBusinessRules trainingBusinessRules)
        {
            _mapper = mapper;
            _trainingRepository = trainingRepository;
            _trainingBusinessRules = trainingBusinessRules;
        }

        public async Task<GetByIdTrainingResponse> Handle(GetByIdTrainingQuery request, CancellationToken cancellationToken)
        {
            Training? training = await _trainingRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _trainingBusinessRules.TrainingShouldExistWhenSelected(training);

            GetByIdTrainingResponse response = _mapper.Map<GetByIdTrainingResponse>(training);
            return response;
        }
    }
}