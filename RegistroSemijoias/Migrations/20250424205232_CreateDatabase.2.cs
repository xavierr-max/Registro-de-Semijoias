using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroSemijoias.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Estoque",
                table: "SemiJoias",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Estoque",
                table: "SemiJoias",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");
        }
    }
}
