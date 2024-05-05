using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Announcements.Commands.Create;

public class CreatedAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public string Picture { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public PrivacyStatus PrivacyStatus { get; set; }
}