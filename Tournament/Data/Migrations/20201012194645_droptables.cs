using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tournament.Data.Migrations
{
    public partial class droptables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDetailStatuses",
                columns: table => new
                {
                    EventDetailStatusID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    TournamentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    EventID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutoClose = table.Column<bool>(type: "bit", nullable: false),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventName = table.Column<string>(type: "varchar(100)", nullable: true),
                    EventNumber = table.Column<short>(type: "smallint", nullable: false),
                    TournamentID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    EventDetailID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDetailName = table.Column<string>(type: "varchar(50)", nullable: true),
                    EventDetailNumber = table.Column<short>(type: "smallint", nullable: false),
                    EventDetailOdd = table.Column<decimal>(type: "decimal(18,7)", nullable: false),
                    EventDetailStatusID = table.Column<short>(type: "smallint", nullable: true),
                    EventID = table.Column<long>(type: "bigint", nullable: true),
                    FinishingPosition = table.Column<short>(type: "smallint", nullable: false),
                    FirstTimer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.EventDetailID);
                    table.ForeignKey(
                        name: "FK_EventDetails_EventDetailStatuses_EventDetailStatusID",
                        column: x => x.EventDetailStatusID,
                        principalTable: "EventDetailStatuses",
                        principalColumn: "EventDetailStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventDetails_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_EventDetailStatusID",
                table: "EventDetails",
                column: "EventDetailStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_EventID",
                table: "EventDetails",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TournamentID",
                table: "Events",
                column: "TournamentID");
        }
    }
}
