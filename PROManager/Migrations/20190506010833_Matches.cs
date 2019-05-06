using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROManager.Migrations
{
    public partial class Matches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee_Ref1Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee_Ref2Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee_Ref3Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee_Ref4Id",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_Ref3Id",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Referee");

            migrationBuilder.RenameColumn(
                name: "Ref4Id",
                table: "Match",
                newName: "SeriesId");

            migrationBuilder.RenameColumn(
                name: "Ref3Id",
                table: "Match",
                newName: "ScoreAwayTeam");

            migrationBuilder.RenameColumn(
                name: "Ref2Id",
                table: "Match",
                newName: "RefereeId");

            migrationBuilder.RenameColumn(
                name: "Ref1Id",
                table: "Match",
                newName: "Referee3Id");

            migrationBuilder.RenameColumn(
                name: "AwayHomeTeam",
                table: "Match",
                newName: "Referee2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Match_Ref4Id",
                table: "Match",
                newName: "IX_Match_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_Ref2Id",
                table: "Match",
                newName: "IX_Match_RefereeId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_Ref1Id",
                table: "Match",
                newName: "IX_Match_Referee3Id");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Referee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArenaId",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Referee1Id",
                table: "Match",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Arena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArenaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arena", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referee1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referee1_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referee2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referee2_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referee3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referee3", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referee3_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeriesName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referee_PersonId",
                table: "Referee",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_ArenaId",
                table: "Match",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Referee1Id",
                table: "Match",
                column: "Referee1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_Referee2Id",
                table: "Match",
                column: "Referee2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Referee1_PersonId",
                table: "Referee1",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Referee2_PersonId",
                table: "Referee2",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Referee3_PersonId",
                table: "Referee3",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Arena_ArenaId",
                table: "Match",
                column: "ArenaId",
                principalTable: "Arena",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee1_Referee1Id",
                table: "Match",
                column: "Referee1Id",
                principalTable: "Referee1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee1_Referee2Id",
                table: "Match",
                column: "Referee2Id",
                principalTable: "Referee1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee1_Referee3Id",
                table: "Match",
                column: "Referee3Id",
                principalTable: "Referee1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee_RefereeId",
                table: "Match",
                column: "RefereeId",
                principalTable: "Referee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Series_SeriesId",
                table: "Match",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Referee_Person_PersonId",
                table: "Referee",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Arena_ArenaId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee1_Referee1Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee1_Referee2Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee1_Referee3Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Referee_RefereeId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Series_SeriesId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Person_PersonId",
                table: "Referee");

            migrationBuilder.DropTable(
                name: "Arena");

            migrationBuilder.DropTable(
                name: "Referee1");

            migrationBuilder.DropTable(
                name: "Referee2");

            migrationBuilder.DropTable(
                name: "Referee3");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Referee_PersonId",
                table: "Referee");

            migrationBuilder.DropIndex(
                name: "IX_Match_ArenaId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_Referee1Id",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_Referee2Id",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "ArenaId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Referee1Id",
                table: "Match");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "Match",
                newName: "Ref4Id");

            migrationBuilder.RenameColumn(
                name: "ScoreAwayTeam",
                table: "Match",
                newName: "Ref3Id");

            migrationBuilder.RenameColumn(
                name: "RefereeId",
                table: "Match",
                newName: "Ref2Id");

            migrationBuilder.RenameColumn(
                name: "Referee3Id",
                table: "Match",
                newName: "Ref1Id");

            migrationBuilder.RenameColumn(
                name: "Referee2Id",
                table: "Match",
                newName: "AwayHomeTeam");

            migrationBuilder.RenameIndex(
                name: "IX_Match_SeriesId",
                table: "Match",
                newName: "IX_Match_Ref4Id");

            migrationBuilder.RenameIndex(
                name: "IX_Match_RefereeId",
                table: "Match",
                newName: "IX_Match_Ref2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Match_Referee3Id",
                table: "Match",
                newName: "IX_Match_Ref1Id");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Referee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Referee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Match_Ref3Id",
                table: "Match",
                column: "Ref3Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee_Ref1Id",
                table: "Match",
                column: "Ref1Id",
                principalTable: "Referee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee_Ref2Id",
                table: "Match",
                column: "Ref2Id",
                principalTable: "Referee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee_Ref3Id",
                table: "Match",
                column: "Ref3Id",
                principalTable: "Referee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Referee_Ref4Id",
                table: "Match",
                column: "Ref4Id",
                principalTable: "Referee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
