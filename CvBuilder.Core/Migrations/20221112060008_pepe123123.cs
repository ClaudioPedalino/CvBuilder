using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvBuilder.Core.Migrations
{
    /// <inheritdoc />
    public partial class pepe123123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsCurrentPosition",
                table: "WorkExperiences",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsCurrentPosition",
                table: "WorkExperiences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
