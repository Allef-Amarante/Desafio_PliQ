using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioPliQ.Migrations
{
    public partial class EstagioAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sequencia",
                table: "Estagios",
                newName: "Priority");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Estagios",
                newName: "Sequencia");
        }
    }
}
