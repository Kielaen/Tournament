using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournament.Data.Migrations
{
    public partial class ForeignKeySetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDetailStatuses",
                columns: table => new
                {
                    EventDetailStatusID = table.Column<short>(type: "smallint", nullable: false),
                    EventDetailStatusName = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetailStatuses", x => x.EventDetailStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentID = table.Column<long>(type: "bigint", nullable: false),
                    TournamentName = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<long>(type: "bigint", nullable: false),
                    FK_TournamentID = table.Column<long>(nullable: false),
                    EventName = table.Column<string>(type: "varchar(100)", nullable: true),
                    EventNumber = table.Column<short>(type: "smallint", nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: false),
                    EventEndDateTime = table.Column<DateTime>(nullable: false),
                    AutoClose = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Tournaments_FK_TournamentID",
                        column: x => x.FK_TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    EventDetailID = table.Column<long>(type: "bigint", nullable: false),
                    FK_EventID = table.Column<long>(nullable: false),
                    FK_EventDetailStatusID = table.Column<short>(nullable: false),
                    EventDetailName = table.Column<string>(type: "varchar(50)", nullable: true),
                    EventDetailNumber = table.Column<short>(type: "smallint", nullable: false),
                    EventDetailOdd = table.Column<decimal>(type: "decimal(18,7)", nullable: false),
                    FinishingPosition = table.Column<short>(type: "smallint", nullable: false),
                    FirstTimer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.EventDetailID);
                    table.ForeignKey(
                        name: "FK_EventDetails_EventDetailStatuses_FK_EventDetailStatusID",
                        column: x => x.FK_EventDetailStatusID,
                        principalTable: "EventDetailStatuses",
                        principalColumn: "EventDetailStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDetails_Events_FK_EventID",
                        column: x => x.FK_EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_FK_EventDetailStatusID",
                table: "EventDetails",
                column: "FK_EventDetailStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_FK_EventID",
                table: "EventDetails",
                column: "FK_EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_FK_TournamentID",
                table: "Events",
                column: "FK_TournamentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "EventDetailStatuses");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
