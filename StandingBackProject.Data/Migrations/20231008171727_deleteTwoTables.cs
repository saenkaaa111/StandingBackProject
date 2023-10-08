using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StandingBackProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteTwoTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTournamentsHistory");

            migrationBuilder.DropTable(
                name: "TeamTournamentsHistory");

            migrationBuilder.DropColumn(
                name: "NumberGame",
                table: "ResultTournamentTeam");

            migrationBuilder.DropColumn(
                name: "NumberRounde",
                table: "ResultTournamentTeam");

            migrationBuilder.DropColumn(
                name: "NumberGame",
                table: "ResultTournamentPlayer");

            migrationBuilder.DropColumn(
                name: "NumberRounde",
                table: "ResultTournamentPlayer");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ResultTournamentTeam",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ResultTournamentPlayer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ResultTournamentTeam");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ResultTournamentPlayer");

            migrationBuilder.AddColumn<int>(
                name: "NumberGame",
                table: "ResultTournamentTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberRounde",
                table: "ResultTournamentTeam",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberGame",
                table: "ResultTournamentPlayer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberRounde",
                table: "ResultTournamentPlayer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlayerTournamentsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTournamentsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTournamentsHistory_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerTournamentsHistory_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamTournamentsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTournamentsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamTournamentsHistory_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamTournamentsHistory_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournamentsHistory_PersonId",
                table: "PlayerTournamentsHistory",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournamentsHistory_TournamentId",
                table: "PlayerTournamentsHistory",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournamentsHistory_TeamId",
                table: "TeamTournamentsHistory",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournamentsHistory_TournamentId",
                table: "TeamTournamentsHistory",
                column: "TournamentId");
        }
    }
}
