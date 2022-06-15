using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                    INSERT INTO Employees (FirstName, MiddleName, LastName)
                    VALUES('Jose', 'Protasio', 'Rizal'),
                           ('Andres', 'Atapangatao', 'Bonifacio'),
                           ('Antionio', 'Anglunas', 'Luna'),
                           ('Cardo', 'Imortal', 'Dalisay')
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
