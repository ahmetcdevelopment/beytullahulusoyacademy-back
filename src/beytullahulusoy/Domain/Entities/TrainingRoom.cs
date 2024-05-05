using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TrainingRoom : Entity<int>
{
    public string Name { get; set; }
    public string Link { get; set; }//Konum. nullable olacak belki koordinat olarak tutabiliriz.
    public double Enlem { get; set; }//salon konumunun enlem koordinatı
    public double Boylam { get; set; }//salon konumunun boylam koordinatı
    public string Address { get; set; }//adres
    public string Picture { get; set; }//Resim

    #region VIRTUAL REFERENCES
    public virtual ICollection<Training> Trainings { get; set; } = default!;//O salondaki antrenmanlar.
    #endregion
}
