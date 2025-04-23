using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NhuThuan_K2023_THIGK.Migrations
{
    /// <inheritdoc />
    public partial class _111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Course");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Enrollment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Enrollment");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Course",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
