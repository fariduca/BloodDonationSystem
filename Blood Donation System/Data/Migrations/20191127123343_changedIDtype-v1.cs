using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blood_Donation_System.Data.Migrations
{
    public partial class changedIDtypev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DonorsModel",
                table: "DonorsModel");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DonorsModel",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "DonorsModel",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonorsModel",
                table: "DonorsModel",
                column: "DonorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DonorsModel",
                table: "DonorsModel");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "DonorsModel");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "DonorsModel",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonorsModel",
                table: "DonorsModel",
                column: "Id");
        }
    }
}
