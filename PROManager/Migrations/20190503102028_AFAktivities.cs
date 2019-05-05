using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROManager.Migrations
{
    public partial class AFAktivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AFAktivityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AFAktivityTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AFAktivityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AFAktivity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    AFAktivityTypeId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AFAktivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AFAktivity_AFAktivityType_AFAktivityTypeId",
                        column: x => x.AFAktivityTypeId,
                        principalTable: "AFAktivityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AFAktivity_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchDateTime = table.Column<DateTime>(nullable: false),
                    HomeTeamId = table.Column<int>(nullable: true),
                    AwayTeamId = table.Column<int>(nullable: true),
                    ScoreHomeTeam = table.Column<int>(nullable: true),
                    AwayHomeTeam = table.Column<int>(nullable: true),
                    Ref1Id = table.Column<int>(nullable: true),
                    Ref2Id = table.Column<int>(nullable: true),
                    Ref3Id = table.Column<int>(nullable: true),
                    Ref4Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Team_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_Ref1Id",
                        column: x => x.Ref1Id,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_Ref2Id",
                        column: x => x.Ref2Id,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_Ref3Id",
                        column: x => x.Ref3Id,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Referee_Ref4Id",
                        column: x => x.Ref4Id,
                        principalTable: "Referee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AFAktivity_AFAktivityTypeId",
                table: "AFAktivity",
                column: "AFAktivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AFAktivity_PersonId",
                table: "AFAktivity",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayTeamId",
                table: "Match",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamId",
                table: "Match",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Ref1Id",
                table: "Match",
                column: "Ref1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Ref2Id",
                table: "Match",
                column: "Ref2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Ref3Id",
                table: "Match",
                column: "Ref3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Ref4Id",
                table: "Match",
                column: "Ref4Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AFAktivity");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "AFAktivityType");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Referee");
        }
    }
}
