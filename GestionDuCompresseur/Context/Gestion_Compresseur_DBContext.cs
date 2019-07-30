using GestionDuCompresseur.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDuCompresseur.Context
{
    public class Gestion_Compresseur_DBContext:DbContext
    {
        public Gestion_Compresseur_DBContext(DbContextOptions<Gestion_Compresseur_DBContext> options) : base(options)
        { }

        public DbSet<CompresseurFiliale> CompresseurFiliales{ get; set; }
        public DbSet<Consommable> Consommables { get; set; }
        public DbSet<Fiche_Suivi> Fiche_Suivis { get; set; }
        public DbSet<FicheCompresseur> FicheCompresseurs { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<GRH> GRHs { get; set; }



    }
}
