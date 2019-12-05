using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blood_Donation_System.Data.Migrations
{
    public partial class newDBv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    DonorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Disease = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.DonorId);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DonationCity = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    DonatonDate = table.Column<string>(nullable: true),
                    CurrentDonorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                    table.ForeignKey(
                        name: "FK_Donations_Donors_CurrentDonorId",
                        column: x => x.CurrentDonorId,
                        principalTable: "Donors",
                        principalColumn: "DonorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CurrentDonorId",
                table: "Donations",
                column: "CurrentDonorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Donors");
        }
    }
}
