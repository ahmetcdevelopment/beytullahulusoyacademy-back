using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Training : Entity<int>
{
    public int RoomId { get; set; }//Antrenman yapılacak salon.
    public int GroupId { get; set; }//Antrenman hangi grupla yapılacak.
    public DateTime StartDate { get; set; }//Antrenman başlangıç saati
    public DateTime EndDate { get; set; }//Antrenman bitiş saati
    public string Note { get; set; }//Antrenman için antrenörün eklediği not.

    #region VIRTUAL REFERENCES
    public virtual TrainingRoom? TrainingRoom { get; set; }
    public virtual Group? Group { get; set; }
    public virtual ICollection<Attendance> Attendances { get; set; } = default!;//İlgili antrenmana ait yoklamalar.
    #endregion
}
