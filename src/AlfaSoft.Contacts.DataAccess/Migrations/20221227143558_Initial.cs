using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaSoft.Contacts.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "Name" },
                values: new object[] { new Guid("68dcb31a-5bbd-446f-8dee-20bb3eb8632e"), "234321234", "ozzy@devil.com", "Ozzy Orbourne" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "Name" },
                values: new object[] { new Guid("7e73d7f6-8490-4614-a514-5ffb61f0996d"), "343234546", "david@spidersfrommars.com", "David Bowie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
