using Application.Features.Recourses.Constants;
using Application.Features.Recourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using Domain.Enums;
using static Application.Features.Recourses.Constants.RecoursesOperationClaims;

namespace Application.Features.Recourses.Commands.Update;

public class UpdateRecourseCommand : IRequest<UpdatedRecourseResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float SizeM { get; set; }
    public float WeightKg { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public RecourseStatus RecourseStatus { get; set; }

    public string[] Roles => [Admin, Write, RecoursesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRecourses"];

    public class UpdateRecourseCommandHandler : IRequestHandler<UpdateRecourseCommand, UpdatedRecourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseRepository _recourseRepository;
        private readonly RecourseBusinessRules _recourseBusinessRules;

        public UpdateRecourseCommandHandler(IMapper mapper, IRecourseRepository recourseRepository,
                                         RecourseBusinessRules recourseBusinessRules)
        {
            _mapper = mapper;
            _recourseRepository = recourseRepository;
            _recourseBusinessRules = recourseBusinessRules;
        }

        public async Task<UpdatedRecourseResponse> Handle(UpdateRecourseCommand request, CancellationToken cancellationToken)
        {
            Recourse? recourse = await _recourseRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseBusinessRules.RecourseShouldExistWhenSelected(recourse);
            recourse = _mapper.Map(request, recourse);

            await _recourseRepository.UpdateAsync(recourse!);

            UpdatedRecourseResponse response = _mapper.Map<UpdatedRecourseResponse>(recourse);
            return response;
        }
    }
}