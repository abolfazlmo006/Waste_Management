using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waste_Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class Deletedroleinuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09904fa6-e275-452f-8765-deb3adc5b98f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "274a9da5-6f1b-4a76-afb9-f7a4776d040b", "AQAAAAIAAYagAAAAEI1YLk+dIQkjaAAbqg2BekbVTX16UEBPSwBsJq++Sjlpr6TdrKVrFWhaCVAq3aLHIg==", "1a131308-8590-4f28-9262-2798aba6931a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09904fa6-e275-452f-8765-deb3adc5b98f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "SecurityStamp" },
                values: new object[] { "1be0365d-1125-4a63-bb30-69c9027cc28e", "AQAAAAIAAYagAAAAEGOy+nohRl1omd6jC8pisahbvABO3R64jXBJSpRtpszCvp4x/Yq+6BvKUgaC0PzBMQ==", "Owner", "5ad00ccf-2f40-4e4d-a29a-63c6ab6c0842" });
        }
    }
}
