using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
/// <summary>
/// Yoklama.
/// </summary>
public class Attendance : Entity<int>
{
    public int TrainingId { get; set; }//Hangi antrenman için yoklama alınıyor.
    public Guid UserId { get; set; }//yoklamayı alan kullanıcı kim?
    public bool IsThere { get; set; }//Katılım sağlayacak mı?
    public string Description { get; set; }//Açıklaması

    #region VIRTUAL REFERENCES
    public virtual Training? Training { get; set; }
    public virtual User? User { get; set; }
    #endregion
}
