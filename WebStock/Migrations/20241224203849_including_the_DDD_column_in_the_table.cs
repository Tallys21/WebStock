using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStock.Migrations
{
    /// <inheritdoc />
    public partial class including_the_DDD_column_in_the_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "Customer",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "DDD",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DDD",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customer",
                newName: "Contact");
        }
    }
}
