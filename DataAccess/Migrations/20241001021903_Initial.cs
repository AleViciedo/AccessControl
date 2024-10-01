using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessControl.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Entry = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Exit = table.Column<DateTime>(type: "TEXT", nullable: true),
                    InBuilding = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CI = table.Column<string>(type: "TEXT", nullable: false),
                    Formation = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    SupervisorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProcessId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Supervisor_ProcessId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Persons_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    ProcessId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.ProcessId);
                    table.ForeignKey(
                        name: "FK_Processes_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessEntries_PersonId",
                table: "AccessEntries",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ProcessId",
                table: "Persons",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Supervisor_ProcessId",
                table: "Persons",
                column: "Supervisor_ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SupervisorId",
                table: "Persons",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_PersonId",
                table: "Processes",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessEntries_Persons_PersonId",
                table: "AccessEntries",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Processes_ProcessId",
                table: "Persons",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Processes_Supervisor_ProcessId",
                table: "Persons",
                column: "Supervisor_ProcessId",
                principalTable: "Processes",
                principalColumn: "ProcessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Persons_PersonId",
                table: "Processes");

            migrationBuilder.DropTable(
                name: "AccessEntries");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Processes");
        }
    }
}
