using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaneSpotter.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SightRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SightRecords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SightRecords",
                columns: new[] { "Id", "DateTime", "Location", "Make", "Model", "Registration" },
                values: new object[] { 1, new DateTime(2022, 8, 27, 13, 33, 7, 408, DateTimeKind.Local).AddTicks(6841), "London Gatwick", "Boeing", "777-300ER", "G-RNAC" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SightRecords");
        }
    }
}
