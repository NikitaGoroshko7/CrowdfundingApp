using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrowdFundingApplication.Migrations
{
    public partial class AddExtraInfoForcreateproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "createProjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "createProjects");
        }
    }
}
