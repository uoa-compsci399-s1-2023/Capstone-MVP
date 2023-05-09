using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone_MVP.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectDescription",
                table: "Projects",
                newName: "Skill");

            migrationBuilder.RenameColumn(
                name: "ProjectDeliverable",
                table: "Projects",
                newName: "Introduction");

            migrationBuilder.RenameColumn(
                name: "PreferredSkill",
                table: "Projects",
                newName: "Approach");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "Projects",
                newName: "ProjectDescription");

            migrationBuilder.RenameColumn(
                name: "Introduction",
                table: "Projects",
                newName: "ProjectDeliverable");

            migrationBuilder.RenameColumn(
                name: "Approach",
                table: "Projects",
                newName: "PreferredSkill");

            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Projects",
                type: "TEXT",
                nullable: true);
        }
    }
}
