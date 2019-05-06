using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROManager.Migrations
{
    public partial class HATeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_AwayTeamId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Team_HomeTeamId",
                table: "Match");

            migrationBuilder.CreateTable(
                name: "AwayTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwayTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwayTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwayTeam_TeamId",
                table: "AwayTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeTeam_TeamId",
                table: "HomeTeam",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_AwayTeam_AwayTeamId",
                table: "Match",
                column: "AwayTeamId",
                principalTable: "AwayTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_HomeTeam_HomeTeamId",
                table: "Match",
                column: "HomeTeamId",
                principalTable: "HomeTeam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_AwayTeam_AwayTeamId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_HomeTeam_HomeTeamId",
                table: "Match");

            migrationBuilder.DropTable(
                name: "AwayTeam");

            migrationBuilder.DropTable(
                name: "HomeTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_AwayTeamId",
                table: "Match",
                column: "AwayTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Team_HomeTeamId",
                table: "Match",
                column: "HomeTeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
