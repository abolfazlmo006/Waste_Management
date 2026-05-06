using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waste_Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class addIsActiveinExhibitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Exhibitors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09904fa6-e275-452f-8765-deb3adc5b98f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8df990d-7012-48f8-abb2-54ded53b3738", "AQAAAAIAAYagAAAAEHeLk9GJDvs1B/mC2GQ1q3gSksHiJwbHigs/zY5jpW/bhYEZLyHYIwk4FYE8GOqFmw==", "037e8581-3502-4e6a-acd2-c7984f17d38e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Exhibitors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09904fa6-e275-452f-8765-deb3adc5b98f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "274a9da5-6f1b-4a76-afb9-f7a4776d040b", "AQAAAAIAAYagAAAAEI1YLk+dIQkjaAAbqg2BekbVTX16UEBPSwBsJq++Sjlpr6TdrKVrFWhaCVAq3aLHIg==", "1a131308-8590-4f28-9262-2798aba6931a" });
        }
    }
}
