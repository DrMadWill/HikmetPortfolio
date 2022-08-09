using Microsoft.EntityFrameworkCore.Migrations;

namespace HikmetRecebli.Migrations
{
    public partial class AddDataA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Email", "Location", "Number" },
                values: new object[] { 1, "iamrajabli@outlook.com", "Azerbaijan, Baku, AZ1000", "+994 55 233 19 19" });

            migrationBuilder.InsertData(
                table: "OnlineAddresses",
                columns: new[] { "Id", "AddressId", "Icon", "Link", "Name" },
                values: new object[] { 1, 1, "<i class='fa-brands fa-github'></i>", "https://github.com/iamrajabli", "Git Hub" });

            migrationBuilder.InsertData(
                table: "OnlineAddresses",
                columns: new[] { "Id", "AddressId", "Icon", "Link", "Name" },
                values: new object[] { 2, 1, "<i class='fa-brands fa-linkedin'></i>", "https://linkedin.com/in/iamrajabli", "LinkedIn" });

            migrationBuilder.InsertData(
                table: "OnlineAddresses",
                columns: new[] { "Id", "AddressId", "Icon", "Link", "Name" },
                values: new object[] { 3, 1, "<i class='fa-brands fa-facebook-square'></i>", "https://facebook.com/iamrajabli", "Facebook" });

            migrationBuilder.InsertData(
                table: "OnlineAddresses",
                columns: new[] { "Id", "AddressId", "Icon", "Link", "Name" },
                values: new object[] { 4, 1, "<i class='fa-brands fa-hackerrank'></i>", "https://hackerrank.com/iamrajabli", "Hacker Rank" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OnlineAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OnlineAddresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OnlineAddresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OnlineAddresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
