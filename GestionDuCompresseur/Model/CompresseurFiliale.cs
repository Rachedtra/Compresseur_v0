using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDuCompresseur.Model
{
    public class CompresseurFiliale
    {
        [Key]
        public int CompFilialeID { get; set; }
        public int CompresseurID { get; set; }
        public int FilialeID { get; set; }
        // Concatination du constructeur+typeComp+num
        public string Name { get; set; }
        //  [RegularExpression("^[0-9]*[.]?[0-9]+", ErrorMessage = "UPRN must be numeric")] , il fau tester avec c exp

        public float MontantTotal { get; set; }
        public float MontantMensuel { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }
        public int Duree { get; set; }
        public FicheCompresseur FicheCompresseur { get; set; }
        ///c est quoi ca   public ICollection<FicheCompresseur> FicheCompresseurs { get; set; } 
        
        public virtual ICollection<Consommable>Consommables { get; set; }
        public virtual ICollection<Fiche_Suivi> Fiche_Suivis { get; set; }

        public virtual ICollection<GRH> GRHs { get; set; }





    }
}
