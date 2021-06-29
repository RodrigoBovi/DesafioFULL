using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioFull.Infra.Data.Migrations
{
    public partial class TBUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TB_USER",
                columns: new[] { "UserId", "EMAIL", "PASSWORD", "USERNAME" },
                values: new object[] { 1, "admin@desafio.com.br", "KjEo+ecA5SzwlfY//yGOgVI0XwFBBAcgJ2R7RtJi/5tE6Y08NyGGVBuwU/ZRICoM", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_USER",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
