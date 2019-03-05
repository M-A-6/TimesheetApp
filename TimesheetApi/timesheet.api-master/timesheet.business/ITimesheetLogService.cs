using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.model;

namespace timesheet.business
{
    public interface ITimesheetLogService
    {
        IQueryable<vwEmployeeWeeklyTasks> GetTimesheetLog();
        List<vwEmployeeWeeklyTasks> getTimesheetlogValues(int employeeId, DateTime date);
        int saveTimesheetLog(List<vwEmployeeWeeklyTasks> timesheetdata);
    }
}
