using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalMusicLibraryOrganizer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertyMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Songs");
        }
    }
}
