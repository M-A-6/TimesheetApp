using Microsoft.EntityFrameworkCore.Migrations;

namespace timesheet.data.Migrations
{
    public partial class addSp_EmployeeWeeklyEfforts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE PROCEDURE [dbo].[sp_EmployeeWeeklyEfforts] 
	-- Add the parameters for the stored procedure here	
	@date datetime 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


select  CONVERT(int, ROW_NUMBER() OVER( ORDER BY e.Id)) Id ,isnull(tsl.LogDate,@date)LogDate, e.Id EmployeeId,isnull(tsl.TaskId,0)TaskId,isnull(tsl.Effort,0)Effort from Employees  e
left  join EmployeeTask et on et.EmployeeId =e.Id
left  join Tasks t on t.Id = et.TaskId
left join TimesheetLog tsl on tsl.TaskId= t.Id and tsl.EmployeeId=e.Id  and tsl.LogDate>=@date and  tsl.LogDate < DATEADD(day,7, @date)




END

GO
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
