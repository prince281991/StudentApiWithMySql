using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApiWithMySql.Migrations
{
    public partial class Student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Contact = table.Column<long>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    PinCode = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
