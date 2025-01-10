using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teledok.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    INN = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    TitleCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCompany = table.Column<int>(type: "int", nullable: false),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEdit = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.INN);
                });

            migrationBuilder.CreateTable(
                name: "Founders",
                columns: table => new
                {
                    INN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Founders", x => x.INN);
                });

            migrationBuilder.CreateTable(
                name: "ClientFounder",
                columns: table => new
                {
                    ClientsINN = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    FoundersINN = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFounder", x => new { x.ClientsINN, x.FoundersINN });
                    table.ForeignKey(
                        name: "FK_ClientFounder_Clients_ClientsINN",
                        column: x => x.ClientsINN,
                        principalTable: "Clients",
                        principalColumn: "INN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientFounder_Founders_FoundersINN",
                        column: x => x.FoundersINN,
                        principalTable: "Founders",
                        principalColumn: "INN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFounder_FoundersINN",
                table: "ClientFounder",
                column: "FoundersINN");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_INN",
                table: "Clients",
                column: "INN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Founders_INN",
                table: "Founders",
                column: "INN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientFounder");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Founders");
        }
    }
}
