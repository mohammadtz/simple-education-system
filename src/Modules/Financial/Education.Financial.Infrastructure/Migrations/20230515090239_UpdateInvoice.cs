using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Financial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPayment",
                table: "Invoices");

            migrationBuilder.AddColumn<Guid>(
                name: "InvoiceId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccess",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsSuccess",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Invoices");

            migrationBuilder.AddColumn<bool>(
                name: "IsPayment",
                table: "Invoices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
