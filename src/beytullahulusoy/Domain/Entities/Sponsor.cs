using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Sponsor : Entity<int>
{
    public string CompanyName { get; set; }
    public string Logo { get; set; }
    public DateTime StartDate { get; set; }//Sponsorluk başlangıç tarihi.
    public DateTime EndDate { get; set; }//Sponsorluk bitiş tarihi.
}
