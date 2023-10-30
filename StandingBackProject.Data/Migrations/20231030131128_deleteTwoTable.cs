using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StandingBackProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteTwoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Team_TeamId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "ResultTournamentTeam");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Person_TeamId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Person");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultTournamentTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultTournamentTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultTournamentTeam_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResultTournamentTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResultTournamentTeam_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_TeamId",
                table: "Person",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultTournamentTeam_GameId",
                table: "ResultTournamentTeam",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultTournamentTeam_TeamId",
                table: "ResultTournamentTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultTournamentTeam_TournamentId",
                table: "ResultTournamentTeam",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Team_TeamId",
                table: "Person",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");
        }
    }
}
