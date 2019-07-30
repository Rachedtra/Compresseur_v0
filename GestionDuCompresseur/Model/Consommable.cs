using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDuCompresseur.Model
{
    public class Consommable
    {
        [Key]
        public int ConsommableID { get; set; }
        public int CompFilialeID { get; set; }
        public CompresseurFiliale CompresseurFiliale { get; set; }
        [Required]
        public int ConsommationComp { get; set; }
        [Required]
        public decimal PrixUnitaire { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        

    }
}
