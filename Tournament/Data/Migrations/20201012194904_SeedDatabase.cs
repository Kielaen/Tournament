using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Tournament.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Tournaments
            migrationBuilder.Sql("Insert into Tournaments (TournamentID,TournamentName) Values (1, 'Tournament1')");
            migrationBuilder.Sql("Insert into Tournaments (TournamentID,TournamentName) Values (2, 'Tournament2')");

            //Events
            migrationBuilder.Sql("Insert into Events (EventID, FK_TournamentID, EventName, EventNumber, EventDateTime, EventEndDateTime, AutoClose) Values (1, 1, 'Round1', 1, '" + DateTime.Now+ "', '" + DateTime.Now + "', 1 )");
            migrationBuilder.Sql("Insert into Events (EventID, FK_TournamentID, EventName, EventNumber, EventDateTime, EventEndDateTime, AutoClose) Values (2, 2, 'Round2', 2, '" + DateTime.Now + "', '" + DateTime.Now + "', 0 )");

            //EventDetailStatuses
            migrationBuilder.Sql("Insert into EventDetailStatuses (EventDetailStatusID, EventDetailStatusName) Values (1, 'Active')");

            //EventDetails
            migrationBuilder.Sql("Insert into EventDetails (EventDetailID, FK_EventID, FK_EventDetailStatusID, EventDetailName,EventDetailNumber, EventDetailOdd, FinishingPosition, FirstTimer) Values (1, 1, 1, 'Round1',1,25, 1, 1 )");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Tournaments");
        }
    }
}
