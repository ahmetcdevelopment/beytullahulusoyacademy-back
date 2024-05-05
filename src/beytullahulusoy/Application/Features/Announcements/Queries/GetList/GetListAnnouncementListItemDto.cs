using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Announcements.Queries.GetList;

public class GetListAnnouncementListItemDto : IDto
{
    public int Id { get; set; }
    public string Picture { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public PrivacyStatus PrivacyStatus { get; set; }
}