using Microsoft.EntityFrameworkCore.Migrations;

namespace HikmetRecebli.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "Image", "Link", "Name" },
                values: new object[] { 1, "https://images.unsplash.com/photo-1498050108023-c5249f4df085?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80", "https://www.youtube.com/watch?v=A1kzr5ldsbU&list=RDR59wcejIp0c&index=12", "Testing" });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "Image", "Link", "Name" },
                values: new object[] { 2, "https://images.unsplash.com/photo-1498050108023-c5249f4df085?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80", "https://www.youtube.com/watch?v=A1kzr5ldsbU&list=RDR59wcejIp0c&index=12", "Testing" });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "Image", "Link", "Name" },
                values: new object[] { 3, "https://images.unsplash.com/photo-1498050108023-c5249f4df085?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=872&q=80", "https://www.youtube.com/watch?v=A1kzr5ldsbU&list=RDR59wcejIp0c&index=12", "Testing" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
