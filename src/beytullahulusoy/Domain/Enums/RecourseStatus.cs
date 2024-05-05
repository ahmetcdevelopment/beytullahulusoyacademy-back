using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;
public enum RecourseStatus
{
    Accepted=0,
    Denied=1,
    OnStandBy=2,//Beklemede.
}
