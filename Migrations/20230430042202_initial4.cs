using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone_MVP.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CommunityImpact1",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CommunityImpact2",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excellence1",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excellence2",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PeopleChoice1",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PeopleChoice2",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommunityImpact1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CommunityImpact2",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Excellence1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Excellence2",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PeopleChoice1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "PeopleChoice2",
                table: "Projects");
        }
    }
}
