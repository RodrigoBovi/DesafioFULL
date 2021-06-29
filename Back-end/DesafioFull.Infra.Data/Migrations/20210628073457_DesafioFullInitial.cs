using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioFull.Infra.Data.Migrations
{
    public partial class DesafioFullInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TB_DEBT_SECURITY",
                columns: table => new
                {
                    DebtSecurityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEBTOR_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEBTOR_CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INTEREST_PERCENT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PENALTY_PERCENT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DEBT_SECURITY", x => x.DebtSecurityId);
                    table.ForeignKey(
                        name: "FK_TB_DEBT_SECURITY_TB_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_USER",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_DEBT_INSTALLMENT",
                columns: table => new
                {
                    DebtInstallmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DUE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    INSTALLMENT_AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebtSecurityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DEBT_INSTALLMENT", x => x.DebtInstallmentId);
                    table.ForeignKey(
                        name: "FK_TB_DEBT_INSTALLMENT_TB_DEBT_SECURITY_DebtSecurityId",
                        column: x => x.DebtSecurityId,
                        principalTable: "TB_DEBT_SECURITY",
                        principalColumn: "DebtSecurityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_DEBT_INSTALLMENT_DebtSecurityId",
                table: "TB_DEBT_INSTALLMENT",
                column: "DebtSecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_DEBT_SECURITY_UserId",
                table: "TB_DEBT_SECURITY",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_DEBT_INSTALLMENT");

            migrationBuilder.DropTable(
                name: "TB_DEBT_SECURITY");

            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}
