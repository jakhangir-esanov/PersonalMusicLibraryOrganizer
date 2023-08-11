using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalMusicLibraryOrganizer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertyMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Singers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Singers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Singers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Singers");
        }
    }
}
