using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_EFile_Company_EF.Migrations
{
    public partial class addingflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FlagEdting",
                table: "contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlagEdting",
                table: "contacts");
        }
    }
}
