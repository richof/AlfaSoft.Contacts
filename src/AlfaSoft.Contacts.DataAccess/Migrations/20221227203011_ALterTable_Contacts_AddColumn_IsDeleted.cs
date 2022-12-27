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
                keyValue: new Guid("68dcb31a-5bbd-446f-8dee-20bb3eb8632e"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("7e73d7f6-8490-4614-a514-5ffb61f0996d"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "Name" },
                values: new object[] { new Guid("d9968de0-88a9-43d6-9b6c-95417823f307"), "234321234", "ozzy@devil.com", "Ozzy Orbourne" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "Name" },
                values: new object[] { new Guid("dc040d27-8fa9-4ebb-8ec4-c14b2fb08e03"), "343234546", "david@spidersfrommars.com", "David Bowie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("d9968de0-88a9-43d6-9b6c-95417823f307"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: new Guid("dc040d27-8fa9-4ebb-8ec4-c14b2fb08e03"));

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "Name" },
                values: new object[] { new Guid("68dcb31a-5bbd-446f-8dee-20bb3eb8632e"), "234321234", "ozzy@devil.com", "Ozzy Orbourne" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactPhone", "Email", "Name" },
                values: new object[] { new Guid("7e73d7f6-8490-4614-a514-5ffb61f0996d"), "343234546", "david@spidersfrommars.com", "David Bowie" });
        }
    }
}
