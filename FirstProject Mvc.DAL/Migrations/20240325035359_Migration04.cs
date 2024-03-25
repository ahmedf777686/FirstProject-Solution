using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstProject_Mvc.DAL.Migrations
{
    public partial class Migration04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "id");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employee",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
