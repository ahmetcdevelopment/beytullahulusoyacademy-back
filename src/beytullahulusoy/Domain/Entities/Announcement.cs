using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
/// <summary>
/// Duyuru
/// </summary>
public class Announcement : Entity<int>
{
    public string Picture { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public PrivacyStatus PrivacyStatus { get; set; }
}
