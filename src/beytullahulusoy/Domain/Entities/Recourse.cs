using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Recourse : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float SizeM { get; set; }//boy
    public float WeightKg { get; set; }//kilo
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public RecourseStatus RecourseStatus { get; set; }
}
