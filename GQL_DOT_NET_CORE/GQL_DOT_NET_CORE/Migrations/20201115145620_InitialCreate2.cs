using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GQL_DOT_NET_CORE.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("dee50489-98d1-4709-8762-59787df65b29"), "John Doe's address", "John Doe" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("4f452002-e708-4311-9bf8-5d42a11ace0e"), "Jane Doe's address", "Jane Doe" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[] { new Guid("89a62d63-102c-4898-9410-35a47979b348"), "Cash account for our users", new Guid("dee50489-98d1-4709-8762-59787df65b29"), 0 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[] { new Guid("c58ded14-1935-4a61-8a4d-0bb9370b518d"), "Savings account for our users", new Guid("4f452002-e708-4311-9bf8-5d42a11ace0e"), 1 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Description", "OwnerId", "Type" },
                values: new object[] { new Guid("501e264c-9e7d-4d6d-9035-7b05f71f3cd6"), "Income account for our users", new Guid("4f452002-e708-4311-9bf8-5d42a11ace0e"), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("501e264c-9e7d-4d6d-9035-7b05f71f3cd6"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("89a62d63-102c-4898-9410-35a47979b348"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("c58ded14-1935-4a61-8a4d-0bb9370b518d"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("4f452002-e708-4311-9bf8-5d42a11ace0e"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("dee50489-98d1-4709-8762-59787df65b29"));
        }
    }
}
