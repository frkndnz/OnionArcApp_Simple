using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArcApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionData",
                table: "Transactions",
                newName: "TransactionDate");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
                column: "CreateDate",
                value: new DateTime(2025, 1, 23, 18, 28, 19, 352, DateTimeKind.Local).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3302"),
                column: "CreateDate",
                value: new DateTime(2025, 1, 23, 18, 28, 19, 352, DateTimeKind.Local).AddTicks(4449));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                table: "Transactions",
                newName: "TransactionData");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
                column: "CreateDate",
                value: new DateTime(2025, 1, 23, 18, 22, 4, 476, DateTimeKind.Local).AddTicks(3719));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8f2504e0-4f89-11d3-9a0c-0305e82c3302"),
                column: "CreateDate",
                value: new DateTime(2025, 1, 23, 18, 22, 4, 476, DateTimeKind.Local).AddTicks(3739));
        }
    }
}
