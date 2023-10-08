using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StandingBackProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

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
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    JudgeId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournament_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tournament_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tournament_Person_JudgeId",
                        column: x => x.JudgeId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

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
                name: "ResultTournamentPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberRounde = table.Column<int>(type: "int", nullable: false),
                    NumberGame = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultTournamentPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultTournamentPlayer_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResultTournamentPlayer_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResultTournamentPlayer_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResultTournamentTeam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberRounde = table.Column<int>(type: "int", nullable: false),
                    NumberGame = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Person_TeamId",
                table: "Person",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournamentsHistory_PersonId",
                table: "PlayerTournamentsHistory",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournamentsHistory_TournamentId",
                table: "PlayerTournamentsHistory",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultTournamentPlayer_GameId",
                table: "ResultTournamentPlayer",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultTournamentPlayer_PersonId",
                table: "ResultTournamentPlayer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultTournamentPlayer_TournamentId",
                table: "ResultTournamentPlayer",
                column: "TournamentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournamentsHistory_TeamId",
                table: "TeamTournamentsHistory",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournamentsHistory_TournamentId",
                table: "TeamTournamentsHistory",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_ClubId",
                table: "Tournament",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_GameId",
                table: "Tournament",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_JudgeId",
                table: "Tournament",
                column: "JudgeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTournamentsHistory");

            migrationBuilder.DropTable(
                name: "ResultTournamentPlayer");

            migrationBuilder.DropTable(
                name: "ResultTournamentTeam");

            migrationBuilder.DropTable(
                name: "TeamTournamentsHistory");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
