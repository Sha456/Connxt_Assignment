using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connxt.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCardValidations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CardValidationConfiguration = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardValidations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardBeginsWithDigit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCardValidationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardProperties_CreditCardValidations_CreditCardValidationId",
                        column: x => x.CreditCardValidationId,
                        principalTable: "CreditCardValidations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardProperties_CreditCardValidationId",
                table: "CreditCardProperties",
                column: "CreditCardValidationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCardProperties");

            migrationBuilder.DropTable(
                name: "CreditCardValidations");
        }
    }
}
