using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YiGong.EntityFrameworkCore.OA.Migrations
{
    public partial class initdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrgName = table.Column<string>(maxLength: 500, nullable: false),
                    OrgType = table.Column<string>(maxLength: 50, nullable: true),
                    OrgClassification = table.Column<string>(maxLength: 50, nullable: true),
                    OrgPhone = table.Column<string>(maxLength: 50, nullable: true),
                    OrgAddress = table.Column<string>(maxLength: 500, nullable: true),
                    OrgCode = table.Column<string>(nullable: true),
                    ParentOrg_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Organization_ParentOrg_Id",
                        column: x => x.ParentOrg_Id,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ParentOrg_Id",
                table: "Organization",
                column: "ParentOrg_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
