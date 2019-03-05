using Microsoft.EntityFrameworkCore.Migrations;

namespace timesheet.data.Migrations
{
    public partial class employeetask_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO EmployeeTask Values(1, 1)
                INSERT INTO EmployeeTask Values(2, 1)
                INSERT INTO EmployeeTask Values(3, 1)
                INSERT INTO EmployeeTask Values(4, 1)
                INSERT INTO EmployeeTask Values(5, 1)
                INSERT INTO EmployeeTask Values(6, 1)
                INSERT INTO EmployeeTask Values(7, 1)
                INSERT INTO EmployeeTask Values(8, 1)
                INSERT INTO EmployeeTask Values(9, 1)
                INSERT INTO EmployeeTask Values(10, 1)
                INSERT INTO EmployeeTask Values(1, 2)
                INSERT INTO EmployeeTask Values(2, 2)
                INSERT INTO EmployeeTask Values(3, 2)
                INSERT INTO EmployeeTask Values(4, 2)
                INSERT INTO EmployeeTask Values(5, 2)
                INSERT INTO EmployeeTask Values(6, 2)
                INSERT INTO EmployeeTask Values(7, 2)
                INSERT INTO EmployeeTask Values(8, 2)
                INSERT INTO EmployeeTask Values(9, 2)
                INSERT INTO EmployeeTask Values(10, 2)

                INSERT INTO EmployeeTask Values(1, 3)
                INSERT INTO EmployeeTask Values(2, 3)
                INSERT INTO EmployeeTask Values(3, 3)
                INSERT INTO EmployeeTask Values(4, 3)
                INSERT INTO EmployeeTask Values(5, 3)
                INSERT INTO EmployeeTask Values(6, 3)
                INSERT INTO EmployeeTask Values(7, 3)
                INSERT INTO EmployeeTask Values(8, 3)
                INSERT INTO EmployeeTask Values(9, 3)
                INSERT INTO EmployeeTask Values(10, 3)



                  GO  ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
