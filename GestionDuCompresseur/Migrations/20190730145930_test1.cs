﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDuCompresseur.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    FournisseurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.FournisseurID);
                });

            migrationBuilder.CreateTable(
                name: "FicheCompresseurs",
                columns: table => new
                {
                    CompresseurID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodeCompresseur = table.Column<int>(nullable: false),
                    TypeCompresseur = table.Column<string>(nullable: true),
                    Constructeur = table.Column<string>(nullable: true),
                    FournisseurID = table.Column<int>(nullable: false),
                    Puissance = table.Column<int>(nullable: false),
                    Debit = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheCompresseurs", x => x.CompresseurID);
                    table.ForeignKey(
                        name: "FK_FicheCompresseurs_Fournisseurs_FournisseurID",
                        column: x => x.FournisseurID,
                        principalTable: "Fournisseurs",
                        principalColumn: "FournisseurID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompresseurFiliales",
                columns: table => new
                {
                    CompFilialeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompresseurID = table.Column<int>(nullable: false),
                    FilialeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MontantTotal = table.Column<float>(nullable: false),
                    MontantMensuel = table.Column<float>(nullable: false),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    Duree = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompresseurFiliales", x => x.CompFilialeID);
                    table.ForeignKey(
                        name: "FK_CompresseurFiliales_FicheCompresseurs_CompresseurID",
                        column: x => x.CompresseurID,
                        principalTable: "FicheCompresseurs",
                        principalColumn: "CompresseurID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consommables",
                columns: table => new
                {
                    ConsommableID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompFilialeID = table.Column<int>(nullable: false),
                    ConsommationComp = table.Column<int>(nullable: false),
                    PrixUnitaire = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consommables", x => x.ConsommableID);
                    table.ForeignKey(
                        name: "FK_Consommables_CompresseurFiliales_CompFilialeID",
                        column: x => x.CompFilialeID,
                        principalTable: "CompresseurFiliales",
                        principalColumn: "CompFilialeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fiche_Suivis",
                columns: table => new
                {
                    FicheSuiviID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    CompFilialeID = table.Column<int>(nullable: false),
                    Nbre_Heurs_Total = table.Column<int>(nullable: false),
                    Nbre_Heurs_Charge = table.Column<int>(nullable: false),
                    Index_Electrique = table.Column<int>(nullable: false),
                    TempsArret = table.Column<double>(nullable: false),
                    Etat = table.Column<int>(nullable: false),
                    FréquenceEentretienDeshuileur = table.Column<string>(nullable: true),
                    CourantAbsorbePhase = table.Column<double>(nullable: false),
                    TypeDernierEntretien = table.Column<string>(nullable: true),
                    PriseCompteur = table.Column<double>(nullable: false),
                    THuileC = table.Column<double>(nullable: false),
                    TSécheurC = table.Column<string>(nullable: true),
                    Remarques = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiche_Suivis", x => x.FicheSuiviID);
                    table.ForeignKey(
                        name: "FK_Fiche_Suivis_CompresseurFiliales_CompFilialeID",
                        column: x => x.CompFilialeID,
                        principalTable: "CompresseurFiliales",
                        principalColumn: "CompFilialeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GRHs",
                columns: table => new
                {
                    GRhID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompFilialeID = table.Column<int>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Salaire = table.Column<decimal>(nullable: false),
                    Charge_Compresseur = table.Column<float>(nullable: false),
                    Charge_Secteur = table.Column<float>(nullable: false),
                    Charge_Total = table.Column<float>(nullable: false),
                    Compresseur_Pourcentage = table.Column<float>(nullable: false),
                    Secheur_Pourcentage = table.Column<float>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRHs", x => x.GRhID);
                    table.ForeignKey(
                        name: "FK_GRHs_CompresseurFiliales_CompFilialeID",
                        column: x => x.CompFilialeID,
                        principalTable: "CompresseurFiliales",
                        principalColumn: "CompFilialeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompresseurFiliales_CompresseurID",
                table: "CompresseurFiliales",
                column: "CompresseurID");

            migrationBuilder.CreateIndex(
                name: "IX_Consommables_CompFilialeID",
                table: "Consommables",
                column: "CompFilialeID");

            migrationBuilder.CreateIndex(
                name: "IX_Fiche_Suivis_CompFilialeID",
                table: "Fiche_Suivis",
                column: "CompFilialeID");

            migrationBuilder.CreateIndex(
                name: "IX_FicheCompresseurs_FournisseurID",
                table: "FicheCompresseurs",
                column: "FournisseurID");

            migrationBuilder.CreateIndex(
                name: "IX_GRHs_CompFilialeID",
                table: "GRHs",
                column: "CompFilialeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consommables");

            migrationBuilder.DropTable(
                name: "Fiche_Suivis");

            migrationBuilder.DropTable(
                name: "GRHs");

            migrationBuilder.DropTable(
                name: "CompresseurFiliales");

            migrationBuilder.DropTable(
                name: "FicheCompresseurs");

            migrationBuilder.DropTable(
                name: "Fournisseurs");
        }
    }
}