using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
/// <summary>
/// Öğrenci grupları
/// </summary>
public class Group : Entity<int>
{
    public Guid UserId { get; set; }//Hoccanın id'si
    public string Name { get; set; }//grubun ismi
    public string Description { get; set; }//açıklama
    public bool IsTrainerGroup { get; set; }

    #region VIRTUAL REFERENCES
    public virtual User? User { get; set; }
    public virtual ICollection<Training> Trainings { get; set; } = default!;//İlgili grubun antrenmanları.
    #endregion
}
