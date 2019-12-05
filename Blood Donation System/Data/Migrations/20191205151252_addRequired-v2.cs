using Microsoft.EntityFrameworkCore.Migrations;

namespace Blood_Donation_System.Data.Migrations
{
    public partial class addRequiredv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Donors",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Donors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
