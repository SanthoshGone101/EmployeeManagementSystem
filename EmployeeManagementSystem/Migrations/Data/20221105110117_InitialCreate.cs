using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystem.Migrations.Data
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "designations",
                columns: table => new
                {
                    SlNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designations", x => x.SlNo);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    SlNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    MailId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.SlNo);
                });

            migrationBuilder.CreateTable(
                name: "paymentRules",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    PaymentTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentRules", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "requestLeaves",
                columns: table => new
                {
                    SlNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<string>(nullable: true),
                    DateOfLeave = table.Column<DateTime>(nullable: false),
                    EndOfLeave = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestLeaves", x => x.SlNo);
                });

            migrationBuilder.CreateTable(
                name: "workingHours",
                columns: table => new
                {
                    SlNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyHour = table.Column<int>(nullable: false),
                    EmployeeHour = table.Column<int>(nullable: false),
                    MonthlyCompanyHour = table.Column<int>(nullable: false),
                    MonthlyEmployeeHour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workingHours", x => x.SlNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "designations");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "paymentRules");

            migrationBuilder.DropTable(
                name: "requestLeaves");

            migrationBuilder.DropTable(
                name: "workingHours");
        }
    }
}
