using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDuCompresseur.Model
{
    public class FicheCompresseur
    {
        [Key]
        public int CompresseurID { get; set; }
        public int CompFilialeID { get; set; }
        public virtual ICollection<CompresseurFiliale> CompresseurFiliales { get; set; }

        public int CodeCompresseur { get; set; }
        public string TypeCompresseur { get; set; }
        public string Constructeur { get; set; }
        public int FournisseurID { get; set; }
        public int Puissance { get; set; }
        public float Debit { get; set; }
       
   


    }
}
