using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEmployees.DAL.Migrations.ExternalClient
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c1f33503-bb38-4fa1-98a0-6cfaf9986797"), "External Client's Test Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("c1f33503-bb38-4fa1-98a0-6cfaf9986797"));
        }
    }
}
