using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlfaSoft.Contacts.DataAccess.Migrations
{
    public partial class ALterTable_Contacts_AddColumn_IsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("d9968de0-88a9-43d6-9b6c-95417823f307"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("dc040d27-8fa9-4ebb-8ec4-c14b2fb08e03"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Contacts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "IsDeleted", "Name" },
                values: new object[] { new Guid("a9627009-cb7e-4524-bac2-3608d7634dfe"), "234321234", "ozzy@devil.com", false, "Ozzy Orbourne" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "IsDeleted", "Name" },
                values: new object[] { new Guid("f048eeca-7402-49ce-b731-fa1005b802fe"), "343234546", "david@spidersfrommars.com", false, "David Bowie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("a9627009-cb7e-4524-bac2-3608d7634dfe"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("f048eeca-7402-49ce-b731-fa1005b802fe"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Contacts");

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "Name" },
                values: new object[] { new Guid("d9968de0-88a9-43d6-9b6c-95417823f307"), "234321234", "ozzy@devil.com", "Ozzy Orbourne" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "Name" },
                values: new object[] { new Guid("dc040d27-8fa9-4ebb-8ec4-c14b2fb08e03"), "343234546", "david@spidersfrommars.com", "David Bowie" });
        }
    }
}
