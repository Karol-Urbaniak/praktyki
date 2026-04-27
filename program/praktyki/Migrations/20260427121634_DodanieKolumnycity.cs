using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace praktyki.Migrations
{
    /// <inheritdoc />
    public partial class DodanieKolumnycity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "clients",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city",
                table: "clients");
        }
    }
}
