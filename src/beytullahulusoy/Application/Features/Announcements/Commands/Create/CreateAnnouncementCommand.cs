using Application.Features.Announcements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Announcements.Commands.Create;

public class CreateAnnouncementCommand : IRequest<CreatedAnnouncementResponse>
{
    public string Picture { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public PrivacyStatus PrivacyStatus { get; set; }

    public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, CreatedAnnouncementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly AnnouncementBusinessRules _announcementBusinessRules;

        public CreateAnnouncementCommandHandler(IMapper mapper, IAnnouncementRepository announcementRepository,
                                         AnnouncementBusinessRules announcementBusinessRules)
        {
            _mapper = mapper;
            _announcementRepository = announcementRepository;
            _announcementBusinessRules = announcementBusinessRules;
        }

        public async Task<CreatedAnnouncementResponse> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            Announcement announcement = _mapper.Map<Announcement>(request);

            await _announcementRepository.AddAsync(announcement);

            CreatedAnnouncementResponse response = _mapper.Map<CreatedAnnouncementResponse>(announcement);
            return response;
        }
    }
}