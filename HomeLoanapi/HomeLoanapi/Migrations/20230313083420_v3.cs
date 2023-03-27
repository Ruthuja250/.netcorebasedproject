using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLoanapi.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Applicationform",
                columns: table => new
                {
                    Application_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aadhar_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pan_card = table.Column<byte>(type: "tinyint", nullable: false),
                    SalarySlip = table.Column<byte>(type: "tinyint", nullable: false),
                    NOC = table.Column<byte>(type: "tinyint", nullable: false),
                    property_location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    property_price = table.Column<double>(type: "float", nullable: false),
                    organisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicationform", x => x.Application_id);
                    table.ForeignKey(
                        name: "FK_Applicationform_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loandetails",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loan_Amount = table.Column<float>(type: "real", nullable: false),
                    EMI = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Application_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loandetails", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_loandetails_Applicationform_Application_Id",
                        column: x => x.Application_Id,
                        principalTable: "Applicationform",
                        principalColumn: "Application_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicationform_userid",
                table: "Applicationform",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_loandetails_Application_Id",
                table: "loandetails",
                column: "Application_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loandetails");

            migrationBuilder.DropTable(
                name: "Applicationform");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
