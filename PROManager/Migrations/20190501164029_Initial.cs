using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefereeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefereeCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefereeCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefereeDistrikt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefereeDistriktName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefereeDistrikt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefereeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefereeTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefereeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Ssn = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RefereeNumber = table.Column<int>(nullable: true),
                    RefereeTypeId = table.Column<int>(nullable: true),
                    RefereeCategoryId = table.Column<int>(nullable: true),
                    RefereeDistriktId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_RefereeCategory_RefereeCategoryId",
                        column: x => x.RefereeCategoryId,
                        principalTable: "RefereeCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_RefereeDistrikt_RefereeDistriktId",
                        column: x => x.RefereeDistriktId,
                        principalTable: "RefereeDistrikt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_RefereeType_RefereeTypeId",
                        column: x => x.RefereeTypeId,
                        principalTable: "RefereeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_RefereeCategoryId",
                table: "Person",
                column: "RefereeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_RefereeDistriktId",
                table: "Person",
                column: "RefereeDistriktId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_RefereeTypeId",
                table: "Person",
                column: "RefereeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "RefereeCategory");

            migrationBuilder.DropTable(
                name: "RefereeDistrikt");

            migrationBuilder.DropTable(
                name: "RefereeType");
        }
    }
}
