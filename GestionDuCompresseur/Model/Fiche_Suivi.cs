﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDuCompresseur.Model
{
    public class Fiche_Suivi
    {
        [Key]
        public int FicheSuiviID { set; get; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
       public int CompFilialeID { get; set; }
        public CompresseurFiliale CompresseurFiliale { get; set; }
        [Required]
        public int Nbre_Heurs_Total { set; get; }
        [Required]
        public int Nbre_Heurs_Charge { set; get; }
        [Required]
        public int Index_Electrique { set; get; }
        public double TempsArret { get; set; }
        public ListeEtat Etat { get; set; }
        public string FréquenceEentretienDeshuileur { get; set; }
        public double CourantAbsorbePhase { get; set; }
        public string TypeDernierEntretien { get; set; }
        public double PriseCompteur { get; set; }
        [Required]
        public double THuileC { get; set; }
        public string TSécheurC { get; set; }
        public string Remarques { get; set; }
        


    }
    public enum ListeEtat { En_marche, En_panne, Reserve }
}
