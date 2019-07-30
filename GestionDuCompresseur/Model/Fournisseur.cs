using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDuCompresseur.Model
{
    public class Fournisseur
    {
        [Key]
        public int FournisseurID { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Adress { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public virtual ICollection<FicheCompresseur> FicheCompresseurs { get; set; }
    }
}
