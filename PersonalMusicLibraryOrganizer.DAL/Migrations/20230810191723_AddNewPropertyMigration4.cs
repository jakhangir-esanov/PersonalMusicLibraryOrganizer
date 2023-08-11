using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalMusicLibraryOrganizer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertyMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Singers",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Singers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Singers");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Singers",
                newName: "Name");
        }
    }
}
