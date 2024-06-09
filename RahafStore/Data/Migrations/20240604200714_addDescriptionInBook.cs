using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RahafStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class addDescriptionInBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Books");
        }
    }
}
