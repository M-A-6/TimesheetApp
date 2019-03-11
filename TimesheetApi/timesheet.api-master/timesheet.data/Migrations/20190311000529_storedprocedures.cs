using Microsoft.EntityFrameworkCore.Migrations;

namespace timesheet.data.Migrations
{
    public partial class storedprocedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                
CREATE PROCEDURE [dbo].[sp_GetTimesheetLogWeekly]
	-- Add the parameters for the stored procedure here
	 @date datetime,		
	 @employeeId int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

select isnull(tslog.Id,0)Id,ISNULL( tslog.LogDate ,@date) LogDate,ISNULL( tslog.TaskId,t.Id)TaskId,ISNULL(tslog.EmployeeId,@employeeId)EmployeeId,isnull(tslog.Effort,0)Effort 
From EmployeeTask et
left join Employees e on e.Id = et.EmployeeId
left join Tasks t on t.Id = et.TaskId
left join Timesheetlog tslog on tslog.EmployeeId = e.Id and tslog.TaskId = t.Id 
and format(tslog.LogDate,'dd/MM/yyyy' ) = FORMAT(@date,'dd/MM/yyyy')
where e.Id = @employeeId
union
select isnull(tslog.Id,0)Id,ISNULL( tslog.LogDate ,DATEADD(day,1, @date)) LogDate,ISNULL( tslog.TaskId,t.Id)TaskId,ISNULL(tslog.EmployeeId,@employeeId)EmployeeId,isnull(tslog.Effort,0)Effort 
From EmployeeTask et
left join Employees e on e.Id = et.EmployeeId
left join Tasks t on t.Id = et.TaskId
left join Timesheetlog tslog on tslog.EmployeeId = e.Id and tslog.TaskId = t.Id 
and format(tslog.LogDate,'dd/MM/yyyy' ) = FORMAT(DATEADD(day,1, @date),'dd/MM/yyyy')
where e.Id = @employeeId
union
select isnull(tslog.Id,0)Id,ISNULL( tslog.LogDate ,DATEADD(day,2, @date)) LogDate,ISNULL( tslog.TaskId,t.Id)TaskId,ISNULL(tslog.EmployeeId,@employeeId)EmployeeId,isnull(tslog.Effort,0)Effort 
From EmployeeTask et
left join Employees e on e.Id = et.EmployeeId
left join Tasks t on t.Id = et.TaskId
left join Timesheetlog tslog on tslog.EmployeeId = e.Id and tslog.TaskId = t.Id 
and format(tslog.LogDate,'dd/MM/yyyy' ) = FORMAT(DATEADD(day,2, @date),'dd/MM/yyyy')
where e.Id = @employeeId
union
select isnull(tslog.Id,0)Id,ISNULL( tslog.LogDate ,DATEADD(day,3, @date)) LogDate,ISNULL( tslog.TaskId,t.Id)TaskId,ISNULL(tslog.EmployeeId,@employeeId)EmployeeId,isnull(tslog.Effort,0)Effort 
From EmployeeTask et
left join Employees e on e.Id = et.EmployeeId
left join Tasks t on t.Id = et.TaskId
left join Timesheetlog tslog on tslog.EmployeeId = e.Id and tslog.TaskId = t.Id 
and format(tslog.LogDate,'dd/MM/yyyy' ) = FORMAT(DATEADD(day,3, @date),'dd/MM/yyyy')
where e.Id = @employeeId
union
select isnull(tslog.Id,0)Id,ISNULL( tslog.LogDate ,DATEADD(day,4, @date)) LogDate,ISNULL( tslog.TaskId,t.Id)TaskId,ISNULL(tslog.EmployeeId,@employeeId)EmployeeId,isnull(tslog.Effort,0)Effort 
From EmployeeTask et
left join Employees e on e.Id = et.EmployeeId
left join Tasks t on t.Id = et.TaskId
left join Timesheetlog tslog on tslog.EmployeeId = e.Id and tslog.TaskId = t.Id 
and format(tslog.LogDate,'dd/MM/yyyy' ) = FORMAT(DATEADD(day,4, @date),'dd/MM/yyyy')
where e.Id = @employeeId
union
select isnull(tslog.Id,0)Id,ISNULL( tslog.LogDate ,DATEADD(day,5, @date)) LogDate,ISNULL( tslog.TaskId,t.Id)TaskId,ISNULL(tslog.EmployeeId,@employeeId)EmployeeId,isnull(tslog.Effort,0)Effort 
From EmployeeTask et
left join Employees e on e.Id = et.EmployeeId
left join Tasks t on t.Id = et.TaskId
left join Timesheetlog tslog on tslog.EmployeeId = e.Id and tslog.TaskId = t.Id 
and format(tslog.LogDate,'dd/MM/yyyy' ) = FORMAT(DATEADD(day,5, @date),'dd/MM/yyyy')
where e.Id = @employeeId

union
select isnull(tslog.Id,0)Id,ISNULL( tslog.LogDate ,DATEADD(day,6, @date)) LogDate,ISNULL( tslog.TaskId,t.Id)TaskId,ISNULL(tslog.EmployeeId,@employeeId)EmployeeId,isnull(tslog.Effort,0)Effort 
From EmployeeTask et
left join Employees e on e.Id = et.EmployeeId
left join Tasks t on t.Id = et.TaskId
left join Timesheetlog tslog on tslog.EmployeeId = e.Id and tslog.TaskId = t.Id 
and format(tslog.LogDate,'dd/MM/yyyy' ) = FORMAT(DATEADD(day,6, @date),'dd/MM/yyyy')
where e.Id = @employeeId

order by LogDate

END

GO




");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
