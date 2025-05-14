using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FruitApi.Migrations
{
    /// <inheritdoc />
    public partial class InitFruits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SYSTEM");

            migrationBuilder.CreateSequence<int>(
                name: "FRUIT_SEQ",
                schema: "SYSTEM");

            migrationBuilder.CreateTable(
                name: "Fruits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "FRUIT_SEQ.NEXTVAL"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Type = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Stock = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fruits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fruits");

            migrationBuilder.DropSequence(
                name: "FRUIT_SEQ",
                schema: "SYSTEM");
        }
    }
}
