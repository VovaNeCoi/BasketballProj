using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballProj.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionType",
                columns: table => new
                {
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionType", x => x.ActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Conference",
                columns: table => new
                {
                    ConferenceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conference", x => x.ConferenceId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    CountryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "MatchupType",
                columns: table => new
                {
                    MatchupTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleType", x => x.MatchupTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<byte[]>(type: "image", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NumberOfLike = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureInGallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Abbr = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    RoleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.SeasonId);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ConferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Division_Conference",
                        column: x => x.ConferenceId,
                        principalTable: "Conference",
                        principalColumn: "ConferenceId");
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    JoinYear = table.Column<DateOnly>(type: "date", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    College = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CountryCode = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Img = table.Column<byte[]>(type: "image", nullable: true),
                    IsRetirment = table.Column<bool>(type: "bit", nullable: false),
                    RetirmentTime = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_Country",
                        column: x => x.CountryCode,
                        principalTable: "Country",
                        principalColumn: "CountryCode");
                    table.ForeignKey(
                        name: "FK_Player_Position",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId");
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Jobnumber = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Passwords = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RoleId = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Jobnumber);
                    table.ForeignKey(
                        name: "FK_Admin_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    Coach = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Abbr = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Stadium = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Logo = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Division",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId");
                });

            migrationBuilder.CreateTable(
                name: "Matchup",
                columns: table => new
                {
                    MatchupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    MatchupTypeId = table.Column<int>(type: "int", nullable: false),
                    Team_Away = table.Column<int>(type: "int", nullable: false),
                    Team_Home = table.Column<int>(type: "int", nullable: false),
                    Starttime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Team_Away_Score = table.Column<int>(type: "int", nullable: false),
                    Team_Home_Score = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CurrentQuarter = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.MatchupId);
                    table.ForeignKey(
                        name: "FK_Matchup_Season",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId");
                    table.ForeignKey(
                        name: "FK_Schedule_SeasonType",
                        column: x => x.MatchupTypeId,
                        principalTable: "MatchupType",
                        principalColumn: "MatchupTypeId");
                    table.ForeignKey(
                        name: "FK_Schedule_Team",
                        column: x => x.Team_Away,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                    table.ForeignKey(
                        name: "FK_Schedule_Team1",
                        column: x => x.Team_Home,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "PlayerInTeam",
                columns: table => new
                {
                    PlayerInTeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    ShirtNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StarterIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerInTeam", x => x.PlayerInTeamId);
                    table.ForeignKey(
                        name: "FK_PlayerInTeam_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_PlayerInTeam_Season",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId");
                    table.ForeignKey(
                        name: "FK_PlayerInTeam_Team",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "PostSeason",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostSeason", x => new { x.TeamId, x.SeasonId });
                    table.ForeignKey(
                        name: "FK_TeamInPostseason_Season",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId");
                    table.ForeignKey(
                        name: "FK_TeamInPostseason_Team",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "MatchupDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchupId = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Team_Away_Score = table.Column<int>(type: "int", nullable: false),
                    Team_Home_Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchupDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchupResult_Schedule",
                        column: x => x.MatchupId,
                        principalTable: "Matchup",
                        principalColumn: "MatchupId");
                });

            migrationBuilder.CreateTable(
                name: "MatchupLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchupId = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    OccurTime = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchupLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchupLog_ActionType",
                        column: x => x.ActionTypeId,
                        principalTable: "ActionType",
                        principalColumn: "ActionTypeId");
                    table.ForeignKey(
                        name: "FK_MatchupLog_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_MatchupLog_Schedule",
                        column: x => x.MatchupId,
                        principalTable: "Matchup",
                        principalColumn: "MatchupId");
                    table.ForeignKey(
                        name: "FK_MatchupLog_Team",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchupId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    IsStarting = table.Column<int>(type: "int", nullable: false),
                    Min = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    Assist = table.Column<int>(type: "int", nullable: false),
                    FieldGoalMade = table.Column<int>(type: "int", nullable: false),
                    FieldGoalMissed = table.Column<int>(type: "int", nullable: false),
                    ThreePointFieldGoalMade = table.Column<int>(type: "int", nullable: false),
                    ThreePointFieldGoalMissed = table.Column<int>(type: "int", nullable: false),
                    FreeThrowMade = table.Column<int>(type: "int", nullable: false),
                    FreeThrowMissed = table.Column<int>(type: "int", nullable: false),
                    Rebound = table.Column<int>(type: "int", nullable: false),
                    OFFR = table.Column<int>(type: "int", nullable: false),
                    DFFR = table.Column<int>(type: "int", nullable: false),
                    Steal = table.Column<int>(type: "int", nullable: false),
                    Block = table.Column<int>(type: "int", nullable: false),
                    Turnover = table.Column<int>(type: "int", nullable: false),
                    Foul = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchupStatistics_Player",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_MatchupStatistics_Schedule",
                        column: x => x.MatchupId,
                        principalTable: "Matchup",
                        principalColumn: "MatchupId");
                    table.ForeignKey(
                        name: "FK_MatchupStatistics_Team",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_RoleId",
                table: "Admin",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_ConferenceId",
                table: "Division",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchup_MatchupTypeId",
                table: "Matchup",
                column: "MatchupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchup_SeasonId",
                table: "Matchup",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchup_Team_Away",
                table: "Matchup",
                column: "Team_Away");

            migrationBuilder.CreateIndex(
                name: "IX_Matchup_Team_Home",
                table: "Matchup",
                column: "Team_Home");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupDetail_MatchupId",
                table: "MatchupDetail",
                column: "MatchupId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupLog_ActionTypeId",
                table: "MatchupLog",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupLog_MatchupId",
                table: "MatchupLog",
                column: "MatchupId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupLog_PlayerId",
                table: "MatchupLog",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchupLog_TeamId",
                table: "MatchupLog",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_CountryCode",
                table: "Player",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Player_PositionId",
                table: "Player",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInTeam_PlayerId",
                table: "PlayerInTeam",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInTeam_SeasonId",
                table: "PlayerInTeam",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerInTeam_TeamId",
                table: "PlayerInTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_MatchupId",
                table: "PlayerStatistics",
                column: "MatchupId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_PlayerId",
                table: "PlayerStatistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_TeamId",
                table: "PlayerStatistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PostSeason_SeasonId",
                table: "PostSeason",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_DivisionId",
                table: "Team",
                column: "DivisionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "MatchupDetail");

            migrationBuilder.DropTable(
                name: "MatchupLog");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "PlayerInTeam");

            migrationBuilder.DropTable(
                name: "PlayerStatistics");

            migrationBuilder.DropTable(
                name: "PostSeason");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "ActionType");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Matchup");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "MatchupType");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Conference");
        }
    }
}
