using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager_WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Prazo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programadores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    ProjetoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programadores_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "Id", "Nome", "Prazo" },
                values: new object[] { 1, "Refatoração Autenticação", new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "Id", "Nome", "Prazo" },
                values: new object[] { 2, "Aplicativo para restaurante", new DateTime(2020, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "Id", "Nome", "Prazo" },
                values: new object[] { 3, "Painel de BI", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "Id", "Nome", "Prazo" },
                values: new object[] { 4, "ChatBot", new DateTime(2020, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Programadores",
                columns: new[] { "Id", "Nome", "ProjetoId", "Telefone" },
                values: new object[] { 4, "Guilherme", 1, "61945123484" });

            migrationBuilder.InsertData(
                table: "Programadores",
                columns: new[] { "Id", "Nome", "ProjetoId", "Telefone" },
                values: new object[] { 7, "Phelipe", 1, "61978543151" });

            migrationBuilder.InsertData(
                table: "Programadores",
                columns: new[] { "Id", "Nome", "ProjetoId", "Telefone" },
                values: new object[] { 3, "Vitor", 2, "61948546512" });

            migrationBuilder.InsertData(
                table: "Programadores",
                columns: new[] { "Id", "Nome", "ProjetoId", "Telefone" },
                values: new object[] { 6, "Marcia", 2, "61978543123" });

            migrationBuilder.InsertData(
                table: "Programadores",
                columns: new[] { "Id", "Nome", "ProjetoId", "Telefone" },
                values: new object[] { 9, "Julia", 2, "61978545548" });

            migrationBuilder.InsertData(
                table: "Programadores",
                columns: new[] { "Id", "Nome", "ProjetoId", "Telefone" },
                values: new object[] { 8, "Ana", 3, "61978541254" });

            migrationBuilder.InsertData(
                table: "Programadores",
                columns: new[] { "Id", "Nome", "ProjetoId", "Telefone" },
                values: new object[] { 1, "Lucas", 4, "61996253833" });

            migrationBuilder.InsertData(
                table: "Programadores",
                columns: new[] { "Id", "Nome", "ProjetoId", "Telefone" },
                values: new object[] { 2, "Vivian", 4, "61999388883" });

            migrationBuilder.InsertData(
                table: "Programadores",
                columns: new[] { "Id", "Nome", "ProjetoId", "Telefone" },
                values: new object[] { 5, "Daniel", 4, "61978546218" });

            migrationBuilder.CreateIndex(
                name: "IX_Programadores_ProjetoId",
                table: "Programadores",
                column: "ProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programadores");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
