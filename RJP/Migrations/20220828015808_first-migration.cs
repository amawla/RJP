using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RJP.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_Id = table.Column<Guid>(nullable: false),
                    Account_No = table.Column<int>(nullable: false),
                    Customer_Id = table.Column<Guid>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modification_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Account_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<Guid>(nullable: false),
                    FName = table.Column<string>(maxLength: 500, nullable: false),
                    LName = table.Column<string>(maxLength: 500, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    Email = table.Column<string>(maxLength: 500, nullable: false),
                    Phone_Number = table.Column<string>(maxLength: 500, nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modification_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Transaction_Id = table.Column<Guid>(nullable: false),
                    Account_Id = table.Column<Guid>(nullable: false),
                    Transaction_No = table.Column<int>(nullable: false),
                    Transaction_Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Transaction_Type = table.Column<string>(maxLength: 500, nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modification_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
